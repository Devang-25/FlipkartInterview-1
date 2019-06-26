using System;
using System.Collections.Generic;
using System.Text;

namespace MakeMeFat
{
    static class Helper
    {
       public static bool ValidateInput(string input)
        {
            if (input.Length == 1 && ( input== "a" || input =="b" || input=="c" || input=="d" || input == "e"))
            {
                return true;
            }
            Console.WriteLine("Invalid Input. Please select correct input");
            return false;
        }
        public static bool ValidateItem(string input)
        {
            string[] entries = input.Split(",");
            if (entries.Length > 4)
            {
                Console.WriteLine("Invalid Input. Please input in id,Name,Price,Calories");
                Program.logger.Error("Invalid Input. Please input in id,Name,Price,Calories");
                return false;
            }
            return true;
        }
    }
}
