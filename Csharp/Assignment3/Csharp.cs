using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    class Csharp: ProgrammingLanguage
    {
        public override string GetInfo()
        {
            this.Name = "Csharp";
            this.Version = 4.6;
            return "Language: " + Name + "\nVersion: " + Version;
        }

        public override string GetSupportedPlatform()
        {
            return "C# Supported Platform: " 
                 + Program.Platform.windows
                 + Program.Platform.iOS
                 + Program.Platform.android; ;
        }
    }
}
