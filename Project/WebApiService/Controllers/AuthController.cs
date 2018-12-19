using AutoMapper;
using DatingApp.BLL;
using DatingApp.BLL.Interface;
using DatingApp.Data;
using DatingApp.WebApiService.Dto;
using DatingApp.WebApiService.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DatingApp.WebApiService.Controllers
{
    [RoutePrefix("api/Auth")]
    [JwtAuthentication]
    public class AuthController : BaseApiController
    {
        private readonly IUserService UserService;
        public AuthController(IDataService _service) : base(_service)
        {
            UserService = Service.UserService;
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto) // FromBody is automaticlly added. just explicit expression
        {
            // ModelState is always related "DataAnnotation"
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
                var existingUser = await UserService.GetUserByName(userForRegisterDto.Username);
                if (existingUser != null)
                {
                    return BadRequest("UserName already exists");
                }

                var userToCreate = Mapper.Map<User>(userForRegisterDto);

                var createdUser = await UserService.Register(userToCreate, userForRegisterDto.Password);
                var userToReturn = Mapper.Map<UserForDetailedDto>(createdUser);

                // return CreatedAtRoute("GetUser", new { controller = "Users", id = createdUser.Id }, userToReturn);
                return StatusCode(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return StatusCode(HttpStatusCode.ExpectationFailed);
            }
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Login(UserForLoginDto userDto)
        {
            try
            {
                var loginUser = await UserService.Login(userDto.Username.ToLower(), userDto.Password);
                if (loginUser == null)
                {
                    return Unauthorized();
                }

                var generatedToken = Utils.GenerateToken(loginUser.Username);
                var user = Mapper.Map<UserForListDto>(loginUser);

                return Ok(new
                {
                    token = generatedToken,
                    user
                });

                // NOTE: how to test
                // 1. http://localhost:55551/api/User/Login from POSTMAN
                // 2. If successful, then you can have some token.
                // 3. Grab it and go to https://jwt.io/ and copy & paste. You can see 3 parts

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return StatusCode(HttpStatusCode.ExpectationFailed);
            }
        }


    }
}
