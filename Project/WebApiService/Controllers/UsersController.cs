using AutoMapper;
using DatingApp.BLL;
using DatingApp.BLL.Helper;
using DatingApp.BLL.Interface;
using DatingApp.Data;
using DatingApp.WebApiService.Dto;
using DatingApp.WebApiService.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
namespace DatingApp.WebApiService.Controllers
{
    [RoutePrefix("api/Users")]
    [JwtAuthentication]
    public class UsersController : BaseApiController
    {
        private readonly IUserService UserService;
        private readonly ILikeService LikeService;

        public UsersController(IDataService _service) : base(_service)
        {
            UserService = Service.UserService;
            LikeService = Service.LikeService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri]UserParams userParams)
        {
            var claims = await IdentityClaims.ToListAsync();
            var claim = await claims.FirstOrDefaultAsync(x => x.Type == ClaimTypes.Name);
            var currentUserName = claim.Value;

            var userFromRepo = await UserService.GetUserByName(currentUserName);

            userParams.UserId = userFromRepo.Id;
            if (userFromRepo.Gender.HasValue)
            {
                userParams.Gender = (bool)userParams.Gender;
            }
            else
            {
                userParams.Gender = false; // Male
            }

            var users = await UserService.GetUsers(userParams);

            var usersToReturn = Mapper.Map<IEnumerable<UserForListDto>>(users);

            HttpContext.Current.Response.AddPagination(users.CurrentPage, users.PageSize,
                users.TotalCount, users.TotalPages);

            return Ok(usersToReturn);
            // return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        [Route("User")]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            var user = await UserService.GetUserById(id);

            var userToReturn = Mapper.Map<UserForDetailedDto>(user);

            return Ok(userToReturn);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> UpdateUser(int id, UserForUpdateDto userForUpdateDto)
        {
            var userFromRepo = await UserService.GetUserById(id);

            Mapper.Map(userForUpdateDto, userFromRepo);

            if (await UserService.SaveChangesAsync() > 0)
                return Content(HttpStatusCode.NoContent, "successfully updated");

            throw new Exception($"Updating user {id} failed on save");
        }

        [HttpPost]
        [Route("{id}/like/{recipientId}")]
        public async Task<IHttpActionResult> LikeUser(int id, int recipientId)
        {
            var like = await LikeService.GetLike(id, recipientId);

            if (like != null)
                return BadRequest("You already like this user");

            if (await UserService.GetUserById(recipientId) == null)
                return NotFound();

            like = new Like
            {
                LikerId = id,
                LikeeId = recipientId
            };

            LikeService.AddLike(like);

            if (await LikeService.SaveChangesAsync() > 0)
                return Ok();

            return BadRequest("Failed to like user");
        }

    }
}
