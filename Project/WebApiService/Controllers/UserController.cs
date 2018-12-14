using AutoMapper;
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
        public async Task<IHttpActionResult> Login(UserForLoginDto user)
        {
            try
            {
                var loginUser = await UserService.Login(user.Username.ToLower(), user.Password);
                if(loginUser == null)
                {
                    return Unauthorized();
                }

                var generatedToken = Utils.GenerateToken(loginUser.Username);

                var userDto = Mapper.Map<UserForListDto>(loginUser);

                return Ok(new
                {
                    token = generatedToken,
                    userDto
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
