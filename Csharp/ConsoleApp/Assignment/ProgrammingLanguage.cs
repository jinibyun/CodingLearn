using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Assignment
{
    public enum Platform
    {
        windows = 1,
        linux = 2,
        unix = 3,
        android = 4,
        iOS = 5
    }

    public class ProgrammingLanguage
    {
        public string name;
        public string version;

        public Platform platform;

        public ProgrammingLanguage(string pname, string pversion, Platform pplatform)
        {
            name = pname;
            version = pversion;
            platform = pplatform;

        }

        public virtual string GetInfo()
        {
            return "";
        }


        //public  abstract enum GetSupportedPlatform()

        //{
        //    return [];
        //}
    }

}
