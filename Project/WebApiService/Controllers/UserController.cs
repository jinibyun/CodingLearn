using DatingApp.BLL;
using DatingApp.BLL.Interface;
using DatingApp.Data;
using DatingApp.WebApiService.Dto;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DatingApp.WebApiService.Controllers
{    
    [RoutePrefix("api/User")]
    public class UserController : BaseApiController
    {
        private readonly IUserService UserService;           
        public UserController(IDataService _service) : base(_service)
        {
            UserService = Service.UserService;            
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Register([FromBody]UserDto user) // FromBody is automaticlly added. just explicit expression
        {
            // ModelState is always related "DataAnnotation"
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                user.UserName = user.UserName.ToLower();
                var existingUser = await UserService.GetUserByName(user.UserName);
                if (existingUser != null)
                {
                    return BadRequest("UserName already exists");
                }

                var userToCreate = new User
                {
                    Username = user.UserName,
                    Created = DateTime.Now,
                    LastActive = DateTime.Now

                };
                var createdUser = await UserService.Register(userToCreate, user.Password);
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
        public async Task<IHttpActionResult> Login(UserDto user)
        {
            try
            {
                var loginUser = await UserService.Login(user.UserName.ToLower(), user.Password);
                if(loginUser == null)
                {
                    return Unauthorized();
                }

                var generatedToken = Utils.GenerateToken(loginUser.Username);

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
