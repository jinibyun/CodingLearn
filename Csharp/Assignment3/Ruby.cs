using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    class Ruby : IProgrammingLangulage
    {
        public string Name { get; set; }
        public double Version { get; set; }
        public string GetInfo()
        {
            this.Name = "Ruby";
            this.Version = 6;
            return "Language: " + Name + "\nVersion: " + Version;
        }

        public string GetSupportedPlatform()
        {
            return "Ruby Supported Platform: "
                 + Program.Platform.windows
                 + Program.Platform.linux
                 + Program.Platform.unix;
        }
    }
}
