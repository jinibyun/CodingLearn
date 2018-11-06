using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    class Java : ProgrammingLanguage
    {
        public override string GetInfo()
        {
            this.Name = "Java";
            this.Version = 10;
            return "Language: " + Name + "\nVersion: " + Version;
        }

        public override string GetSupportedPlatform()
        {
            return "Java Supported Platform: "
                 + Program.Platform.windows
                 + Program.Platform.iOS
                 + Program.Platform.linux
                 + Program.Platform.unix
                 + Program.Platform.android;
        }
    }
}
