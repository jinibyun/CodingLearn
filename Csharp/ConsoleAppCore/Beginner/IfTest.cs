﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCore.Beginner
{
    public class IfTest
    {
        public void Test()
        {
            // if statement
            int number = 12;

            if (number < 5)
            {
                Console.WriteLine("{0} is less than 5", number);
            }
            else if (number > 5)
            {
                Console.WriteLine("{0} is greater than 5", number);
            }
            else
            {
                Console.WriteLine("{0} is equal to 5");
            }

            // switch
            char ch;
            Console.WriteLine("Enter an alphabet for switch test");
            ch = Convert.ToChar(Console.ReadLine());

            switch (Char.ToLower(ch))
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    Console.WriteLine("Vowel");
                    break;
                default:
                    Console.WriteLine("Not a vowel");
                    break;
            }
        }
    }
}
