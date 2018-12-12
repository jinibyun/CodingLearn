using DatingApp.BLL;
using DatingApp.Data;
using DatingApp.Data.Implementation;
using DatingApp.Data.Interface;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace DatingApp.WebApiService
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
			var container = new UnityContainer();                      
            container.RegisterType<IDatingAppData, DatingAppData>(new HierarchicalLifetimeManager());
            container.RegisterType<IDataService, DataService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}