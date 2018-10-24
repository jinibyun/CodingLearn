using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Assignment
{
    public abstract class ProgrammingLanguage
    {
        public string name = "";
        public string version = "";
        private Platform type;

        public virtual string getInfo()
        {
            return "Programming Language : " + name + version;
        }

        public abstract double Cost();

        public void setType(Platform type)
        {
            this.type = type;
        }

        public Platform GetSurportedPlatform()
        {
            return this.type;
        }
    }

    public enum Platform
    {
        windows = 1,
        linux = 2,
        unix = 3,
        android = 4,
        iOS = 5
    }

    public class Csharp : ProgrammingLanguage
    {
        public Csharp(Platform pType)
        {
            setType(pType);
        }

        public override string getInfo()
        {
            return "Programming Language : " + name + version;
        }

        public override double Cost()
        {
            return 100;
        }
    }
    public class HTML : ProgrammingLanguage
    {
        public HTML(Platform pType)
        {
            setType(pType);
        }
        public override double Cost()
        {
            return 150;
        }

    }

    public class CSS : ProgrammingLanguage
    {
        public CSS(Platform pType)
        {
            setType(pType);
        }
        public override double Cost()
        {
            return 200;
        }

    }

    public abstract class Java : ProgrammingLanguage
    {
    }

    public class Javascript : Java
    {
        ProgrammingLanguage language;

        public Javascript(ProgrammingLanguage language)
        {
            this.language = language;

        }

        public override string getInfo()

        {
            return language.getInfo() + ",From Java";
        }

        public override double Cost()
        {
            double cost = language.Cost();
            if (GetSurportedPlatform() == Platform.windows) cost += 100;
            else if (GetSurportedPlatform() == Platform.linux) cost += 200;
            else if (GetSurportedPlatform() == Platform.android) cost += 150;
            return cost;
        }

    }

}
