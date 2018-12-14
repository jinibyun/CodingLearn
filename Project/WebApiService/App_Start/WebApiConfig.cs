using DatingApp.WebApiService.App_Start;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DatingApp.WebApiService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Dependency Injection
            UnityConfig.RegisterComponents(config);

            // Logging
            log4net.Config.XmlConfigurator.Configure();

            // Attribute Routing
            config.MapHttpAttributeRoutes();

            // Web API configuration and services
            // To prevent any anonymous request to your resources.
            config.Filters.Add(new AuthorizeAttribute());

            // Auto Mapping
            // initialize automapper between domain and Dto (Data Transfer Object)
            AutoMapperConfiguration.Configure();

            //Support for CORS (Cross Origin Resource Sharing)
            EnableCorsAttribute CorsAttribute = new EnableCorsAttribute("*", "*", "GET,POST");
            config.EnableCors(CorsAttribute);

            // default
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}", // URL pattern of the route
                defaults: new { id = RouteParameter.Optional } // An object parameter that includes default route values
            );

            // Now all JSON objects properties return in camel case
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
