using System.Configuration;

namespace ConsoleAdoNet
{
    public abstract class BaseClass
    {
        protected string connectionString = ConfigurationManager.AppSettings["PubsConnectionString"];
        public abstract void Test();
    }
}