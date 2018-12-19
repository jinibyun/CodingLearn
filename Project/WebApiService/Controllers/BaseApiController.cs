using DatingApp.BLL;
using DatingApp.WebApiService.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;

namespace DatingApp.WebApiService.Controllers
{
    /// <summary>
    /// Base Controller
    /// </summary>
    public class BaseApiController : ApiController
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected readonly IDataService _service;        
        private ModelFactory _modelFactory;

        public BaseApiController(IDataService service)
        {
            _service = service;           
        }

        protected IDataService Service
        {
            get
            {
                return _service;
            }
        }

        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory();
                }
                return _modelFactory;
            }
        }

        protected IEnumerable<Claim> IdentityClaims
        {
            get
            {
                var identity = (ClaimsIdentity)User.Identity;
                return identity.Claims;
            }
        }
    }
}
