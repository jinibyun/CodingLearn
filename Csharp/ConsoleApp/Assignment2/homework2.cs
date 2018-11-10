using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Assignment2
{
    class homework2
    {
        public void Test2()
        {

            //1. Sum of all odd numbers from 1 to 100
            int sum1 = 0;
            int i = 1;
            //increment by 2 which only takes odd number
            for (i = 1; i <= 100; i=i+2)    
            {
                sum1 += i;      
            }
            Console.WriteLine("Sum of all odd number from 1 to 100 is: {0}", sum1);
            Console.WriteLine("============================");


            //2. Above task using while loop
            int sum2 = 0;
            i = 1;
            while (i <= 100)
            {
                sum2 += i;
                i = i + 2;  //another increment by 2 to select only odd
            }
            Console.WriteLine("Sum of all odd number from 1 to 100 is: {0}", sum2);
            Console.WriteLine("============================");


            //3.Loop using foreach and print all numbers in array but excluding repeats.
            int[] oddArray = new int[] { 1, 3, 3, 3, 5, 7, 9, 9, 9, 11, 11, 13, 15, 17, 17, 19, 21 };
            i = 0;
            int previousnumber = 0;
            foreach (int index in oddArray)
            {
                if (previousnumber != index)
                    Console.WriteLine(index);

                previousnumber = index;
            }
            Console.WriteLine("============================");


            //4.var vs dynamic difference
            var var_num = "Hello World";          //declare string as var
            //var_num = 32;                       //var can't change type, also error caught at compile (Can't run)
            dynamic dyn_num = "Hello World";      //declare string as dynaic
            dyn_num = 32;                         //dynamic can change type
            //Console.WriteLine(dyn_num.Length);  //error caught at run (run but error message)


            //5.Switch Statement
            Console.WriteLine("********ATM********");
            Console.WriteLine("1.Balance");
            Console.WriteLine("2.Withdraw");
            Console.WriteLine("3.Depsoit");
            Console.WriteLine("4.Exit");
            Console.WriteLine("*******************");
            string input = Console.ReadLine();
            int option = Convert.ToInt32(input);
            switch (option)
            {
                case 1:
                    Console.WriteLine("$1000");
                    break;
                case 2:
                    Console.WriteLine("$900. Would you like a receipt");
                    break;
                case 3:
                    Console.WriteLine("$1100. Would you like a receipt");
                    break;
                case 4:
                    Console.WriteLine("See You Again");
                    break;
                default:
                    Console.WriteLine("Invalid Entry");
                    break;
            }
            Console.WriteLine("============================");


            //6.Ref vs Out Keyword
            int x = 2;          //For 'ref', variable must be initialized in calling method
            int y = 4;          
            int z;              //when the value is unknown, we may use 'out'
            int q;
            Console.WriteLine(Ref_Out(ref x, ref y));
            Console.WriteLine(Ref_Out2(out z, out q));
            Console.WriteLine("============================");


            //7.Params
            TestParams("abc", "xyz", "www", "http", "This", "That");
            Console.WriteLine("============================");

            //8.? operator
            bool IsDeveloper;
            Console.WriteLine("Enter the passcode");
            String SomeVariable = Console.ReadLine();
            IsDeveloper  = (SomeVariable == "developer") ? true : false;
            Console.WriteLine(IsDeveloper);
            Console.WriteLine("============================");

            //9.?? operator
            DateTime? dt1= null;
            DateTime dt2;
            dt2 = dt1 ?? DateTime.Now;      //if dt1 is not null, set dt2 to dt1.
            Console.WriteLine(dt2);         //Otherwise, if dt1 = null, which it is, set dt2 = DateTime.Now
            Console.WriteLine("============================");


        }   //End of Test2()


        //6.Ref vs Out keyword
        public int Ref_Out (ref int x, ref int y)
        {
            int sum3;
            sum3 = x + y;
            return sum3;
        }
        public int Ref_Out2 (out int z, out int q)
        {
            z = 10;     //For 'out', variable must be initialized in called method
            q = 6;      
            int sum4 = z+q;
            return sum4;
        }

        //7.Params
        public static void TestParams(params string[] arg)
        {
            string words="";
            foreach (string argu in arg)
            {
                words = words + argu + ",";
            }
            Console.WriteLine(words);
        }
    }   //End of homework2


    //10. Product Class- member, fields, property, enum
    class Product
    {
        //5 fields
        private string productName;
        private string productType;
        private string productCode;
        private double productPrice;
        private int productQuantity;

        //Constructor
        public Product (string name, string type, string code, double price, int quantity)
        {
            productName = name;
            productType = type;
            productCode = code;
            productPrice = price;
            productQuantity = quantity;
        }

        //enum
        public enum Stock
        {
            InStock,
            OutofStock
        }

        //Properties
        public string Name
        {
            get { return this.productName;}
            set { productName = value; }
        }
        public string Type
        {
            get { return this.productType;}
            set { productType = value; }
        }
        public string Code
        {
            get { return this.productCode;}
            set { productCode = value; }
        }
        public double Price
        {
            get {return this.productPrice;}
            set
            {
                if (productPrice >= 0)
                    productPrice=value;                   
            }
        }
        public int Quantity
        {
            get { return this.productQuantity;}
            set
            {
                if (productQuantity >= 0)
                    productQuantity = value;
            }
        }

        //method getItem
        public void getItem(string Code)
        {
            string[] item = { productName, productType };
            if (Code == "0X333")
            {
                foreach (string m in item) Console.Write(m + " | ");

                Console.WriteLine(productPrice + " | " + productQuantity);
            }
        }
    }   //End of Product
}
