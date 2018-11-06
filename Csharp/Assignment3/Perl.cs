using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    class Perl : IProgrammingLangulage
    {
        public string Name { get; set; }
        public double Version { get; set; }

        public string GetInfo()
        {
            this.Name = "Perl";
            this.Version = 8;
            return "Language: " + Name + "\nVersion: " + Version;
        }


        public string GetSupportedPlatform()
        {
            return "Perl Supported Platform: "
                 + Program.Platform.windows
                 + Program.Platform.iOS
                 + Program.Platform.linux
                 + Program.Platform.unix
                 + Program.Platform.android;

        }
    }
}
