using AutoMapper;
using DatingApp.BLL;
using DatingApp.BLL.Interface;
using DatingApp.WebApiService.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;


namespace DatingApp.WebApiService.Controllers
{
    
    [RoutePrefix("api/Values")]
    [JwtAuthentication]
    // [Authorize]
    public class ValuesController : BaseApiController
    {
        private readonly IValueService ValueService;
        public ValuesController(IDataService _service) : base(_service)
        {
            ValueService = Service.ValueService;
        }

        [HttpGet]
        // [AllowAnonymous]
        public async Task<IHttpActionResult> Get()
        {           
            try
            {
                var values = await ValueService.GetAllValue();
                return Ok(values);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var value = await ValueService.GetValue(id);
                return Ok(value);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
