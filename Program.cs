using System;
using System.Text.RegularExpressions;
using assignmnet_301.Menu;
using assignmnet_301.User;
using assignmnet_301.Tools;

namespace assignmnet_301
{
    class Program
    {
        //fields
        public static Member LoginMember;
        public static ToolCollection toolCollection = new ToolCollection();
        public static ToolLibrarySystem toolLibrarySystem = new ToolLibrarySystem();

        //Main program
        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();
            StaffMenu staffMenu = new StaffMenu();
            MemberMenu memberMenu = new MemberMenu();
            double option = -1;


            while (option != 0)
            {
                mainMenu.GetMenu();
                option = mainMenu.GetUserNum(prompt: "\n Select an option: ", min: 0, max: 4, wholeNumber: true); 
                if (option == 1) //staff login
                {
                    Console.Clear();
                    string staffID;
                    string staffPassword;
                    do
                    {
                        Console.WriteLine("Enter your staff id: ");
                        staffID = Console.ReadLine();
                    }
                    while (staffID != "staff");

                    do
                    {
                        Console.WriteLine("Enter your staff acccount passwords: ");
                        staffPassword = Console.ReadLine();
                    } while (staffPassword != "today123");
                    Console.Clear();
                    staffMenu.GetMenu();
                }
                else if (option == 2) //member login
                {
                    Console.Clear();
                    if (toolLibrarySystem.ValidUserHandle(LoginMember) == true)
                    {
                        memberMenu.GetMenu(toolLibrarySystem.getUserHandle());
                     }
                    else
                    {
                        Console.WriteLine("Invalid User!");
                        Console.ReadLine();
                        mainMenu.GetMenu();
                    }

                }
                
            }
            //if the chosen is 0(Exit) 
            Console.WriteLine("Good Bye");
            Console.ReadLine();
        }
       

        }                                                                                                                                                                                                                                                     
}

