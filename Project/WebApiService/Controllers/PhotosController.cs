using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DatingApp.BLL;
using DatingApp.BLL.Interface;
using DatingApp.Data;
using DatingApp.WebApiService.Dto;
using DatingApp.WebApiService.Filters;
using DatingApp.WebApiService.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace DatingApp.WebApiService.Controllers
{
    [JwtAuthentication]
    public class PhotosController : BaseApiController
    {
        private readonly IPhotoService PhotoService;
        private readonly IUserService UserService;

        // ref: https://cloudinary.com/documentation/dotnet_integration#dotnet_getting_started_guide
        private Cloudinary _cloudinary;

        public PhotosController(IDataService _service) : base(_service)
        {
            UserService = Service.UserService;
            PhotoService = Service.PhotoService;

            Account acc = new Account(
                Constant.Cloudinary_Name,
                Constant.Cloudinary_ApiKey,
                Constant.Cloudinary_ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }

        //[HttpGet]
        //[AllowAnonymous]
        //public IHttpActionResult Get()
        //{
        //    return Ok("test");
        //}

        [HttpGet]
        [Route("{id}", Name = "GetPhoto")]
        public async Task<IHttpActionResult> GetPhoto(int id)
        {
            var photoFromRepo = await PhotoService.GetPhoto(id);

            var photo = Mapper.Map<PhotoForReturnDto>(photoFromRepo);

            return Ok(photo);
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddPhotoForUser(int userId /*, PhotoForCreationDto photoForCreationDto*/ )
        {
            try
            {
                var userFromRepo = await UserService.GetUserById(userId);

                // var file = photoForCreationDto.File;

                var uploadResult = new ImageUploadResult();

                var httpRequest = HttpContext.Current.Request;

                var file = httpRequest.Files[0];
                if (file.ContentLength > 0)
                {
                    using (var stream = file.InputStream)
                    {
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(file.FileName, stream),
                            Transformation = new Transformation()
                                .Width(500).Height(500).Crop("fill").Gravity("face")
                        };

                        uploadResult = _cloudinary.Upload(uploadParams);
                    }
                }

                var photoForCreationDto = new PhotoForCreationDto();
                
                photoForCreationDto.Url = uploadResult.Uri.ToString();
                photoForCreationDto.PublicId = uploadResult.PublicId;

                var photo = Mapper.Map<Photo>(photoForCreationDto);
                photo.UserId = userId;
                if (!userFromRepo.Photos.Any(u => u.IsMain))
                    photo.IsMain = true;
                

                userFromRepo.Photos.Add(photo);                
                
                
                if (PhotoService.AddPhoto(photo))
                {
                    var photoToReturn = Mapper.Map<PhotoForReturnDto>(photo);
                    return CreatedAtRoute("GetPhoto", new { id = photo.Id }, photoToReturn);
                }

                return BadRequest("Could not add the photo");
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return InternalServerError(ex);
            }
        }

        //[HttpPost]
        //[Route("{id}/setMain")]
        //public async Task<IHttpActionResult> SetMainPhoto(int userId, int id)
        //{
        //    var user = await UserService.GetUserById(userId);

        //    if (!user.Photos.Any(p => p.Id == id))
        //        return Unauthorized();

        //    var photoFromRepo = await PhotoService.GetPhoto(id);

        //    if (photoFromRepo.IsMain)
        //        return BadRequest("This is already the main photo");

        //    var currentMainPhoto = await PhotoService.GetMainPhotoForUser(userId);
        //    currentMainPhoto.IsMain = false;

        //    photoFromRepo.IsMain = true;

        //    if (await PhotoService.SaveChangesAsync() > 0)
        //        return Content(HttpStatusCode.NoContent, "successfully set");

        //    return BadRequest("Could not set photo to main");
        //}

        //[HttpDelete]
        //[Route("{id}")]
        //public async Task<IHttpActionResult> DeletePhoto(int userId, int id)
        //{
        //    var user = await UserService.GetUserById(userId);

        //    if (!user.Photos.Any(p => p.Id == id))
        //        return Unauthorized();

        //    var photoFromRepo = await PhotoService.GetPhoto(id);

        //    if (photoFromRepo.IsMain)
        //        return BadRequest("You cannot delete your main photo");

        //    if (photoFromRepo.PublicId != null)
        //    {
        //        var deleteParams = new DeletionParams(photoFromRepo.PublicId);

        //        var result = _cloudinary.Destroy(deleteParams);

        //        if (result.Result == "ok")
        //        {
        //            PhotoService.DeletePhoto(photoFromRepo);
        //        }
        //    }

        //    if (photoFromRepo.PublicId == null)
        //    {
        //        PhotoService.DeletePhoto(photoFromRepo);
        //    }

        //    if (await PhotoService.SaveChangesAsync() > 0)
        //        return Ok();

        //    return BadRequest("Failed to delete the photo");
        //}
    }
}
