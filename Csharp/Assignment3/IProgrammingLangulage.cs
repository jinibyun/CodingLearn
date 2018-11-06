using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    interface IProgrammingLangulage
    {
        string Name { get; set; }

        double Version { get; set; }

        string GetInfo();

        string GetSupportedPlatform();
    }
}
