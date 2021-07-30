using System;
using System.Collections.Generic;
using System.Text;

namespace assignmnet_301.Menu
{
    public class MainMenu : Menu

    {
        //Contructor
        public void GetMenu()
        {
            Console.Clear();
            Console.WriteLine("============== Welcome to the Tool Library ============");
            Console.WriteLine("====================== MAIN MENU ======================");
            Console.WriteLine("1. Staff Login");
            Console.WriteLine("2. Member Login");
            Console.WriteLine("0. Exit");
            Console.WriteLine("=======================================================");
            Console.Write("Please make a selection (1-2, or 0 to exit):");
        }
        /// <summary>
        /// get number valid from user
        /// </summary>
        /// <param name="prompt">message to display</param>
        /// <param name="min">min number</param>
        /// <param name="max">max number</param>
        /// <param name="wholeNumber">whold number or not</param>
        /// <param name="inclusive">inclusive or not</param>
        /// <returns></returns>
        public double GetUserNum(
                   string prompt = "\n Select an option: ",
                   double min = double.MinValue,
                   double max = double.MaxValue,
                   bool wholeNumber = false,
                   bool inclusive = true
               )
        {
            bool valid = false;
            double option = 0;
            do
            {
                Console.WriteLine(prompt);
                /// <summary>
                /// This try function is used to check if the input from the user is not number
                /// </summary>
                try
                {
                    option = double.Parse(Console.ReadLine());
                    if (inclusive == false && option < min)
                    {
                        Console.WriteLine($"\n Input must be greater than {min}!");
                    }
                    else if (inclusive == false && option > max)
                    {
                        Console.WriteLine($"\n Input must be smaller than {max}!");
                    }
                    else if (wholeNumber == true && option != (int)option)
                    {
                        Console.WriteLine("\n Input must be a whole number!");
                    }
                    else if (option < min)
                    {
                        Console.WriteLine($"\n Input must be at least {min}!");
                    }
                    else if (option > max)
                    {
                        Console.WriteLine($"\n Input must be at most {max}!");
                    }
                    else
                    {
                        valid = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n Input must be numeric!");
                }

            } while (!valid);
            return option;
        }
        
    }
}
