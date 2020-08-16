using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCore.Beginner
{
    // integer grouping data type
    public enum City
    {
        Seoul,   // 0
        Daejun,  // 1
        Busan = 5,  // 5
        Jeju = 10   // 10
    }

    public class EnumTest
    {
        City myCity;

        public void Test()
        {
            // Access to enum
            myCity = City.Seoul;

            // enum to int casting
            int cityValue = (int)myCity;

            if (myCity == City.Seoul) // enum comparison
            {
                Console.WriteLine("Welcome to Seoul");
            }

            // convert int to enum
            string j = "10";

            // YourEnum foo = (YourEnum)Enum.Parse(typeof(YourEnum), yourString);
            City c = (City)Enum.Parse(typeof(City), j);
            Console.WriteLine(c.ToString());

            // ToString() <------> Parse()

            // ToString()
            // All Data can be converted into string
            // e.g
            // 1.34  -->> "1.34"
            // 2020-12-32 T23:45:12 00:00:00 -->> "2020-12-32 T23:45:12 00:00:00"

            // Parse
            // Not all string data can be converted into target data type
            // e.g
            // "true" -->> bool: true (0)
            // "1.357" -->> datetime (x)

        }
    }
}
