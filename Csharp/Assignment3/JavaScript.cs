using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    class JavaScript : Java
    {
        public override string GetInfo()
        {
            this.Name = "JavaScript";
            this.Version = 5;
            return "Language: " + Name + "\nVersion: " + Version;
        }

        public string GetInfo(string name, double version)
        {
            this.Name = name;
            this.Version = version;
            return "Language: " + Name + "\nVersion: " + Version;
        }
        public override string GetSupportedPlatform()
        {
            return "JS Supported Platform: "
                 + Program.Platform.windows
                 + Program.Platform.iOS
                 + Program.Platform.linux
                 + Program.Platform.unix
                 + Program.Platform.android; ;
        }
    }
}
