using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    class Python : IProgrammingLangulage
    {
        public string Name { get; set; }
        public double Version { get; set; }
        public string GetInfo()
        {
            this.Name = "Python";
            this.Version = 7;
            return "Language: " + Name + "\nVersion: " + Version;
        }

        public string GetSupportedPlatform()
        {
            return "Python Supported Platform: "
                 + Program.Platform.windows
                 + Program.Platform.linux
                 + Program.Platform.unix;
        }
    }
}
