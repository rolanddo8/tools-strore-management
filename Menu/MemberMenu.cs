using System;
using assignmnet_301.Tools;
using assignmnet_301.User;
using System.Collections.Generic;
using System.Text;

namespace assignmnet_301.Menu
{
    class MemberMenu 
    {
        //fields
        MainMenu mainMenu;
        private static ToolLibrarySystem toolLibrarySystem = Program.toolLibrarySystem;

        //Contructor
        public MemberMenu()
        {
            mainMenu = new MainMenu();
        }
        public void GetMenu(Member aMember)
        {
            Console.Clear();
            //get Member menu
            Console.WriteLine("===================== Member MENU =====================");
            Console.WriteLine("1. Display all the tools of a tool type");
            Console.WriteLine("2. Borrow a tool");
            Console.WriteLine("3. Return a tool");
            Console.WriteLine("4. List all the tools that I am renting");
            Console.WriteLine("5. Display top three (3) most frequently rented tools");
            Console.WriteLine("0. Return to Main Menu");
            Console.WriteLine("======================================================");
            Console.WriteLine();
            Console.Write("Please make a selection (1-5, or 0 to return to main menu):");

            double MemOption = mainMenu.GetUserNum(prompt: "\n Select an option: ", min: 0, max: 5, wholeNumber: true);

            if (MemOption == 1) // member want to display all the tool
            {
                Console.Clear();
                toolLibrarySystem.displayTools();
                Console.WriteLine("Press anykey to return to the Staff Menu: ");
                Console.ReadLine();
                Console.Clear();
                GetMenu(aMember);
            }
            else if (MemOption == 2) // member want to borrow a tool
            {
                Console.Clear();
                toolLibrarySystem.borrowToolHandle(aMember);
                Console.WriteLine("Press anykey to return to the Staff Menu: ");
                Console.ReadLine();
                Console.Clear();
                GetMenu(aMember);
            }
            else if (MemOption == 3) //member want to return a tool
            {
                Console.Clear();
                toolLibrarySystem.returnToolHandle(aMember);
                Console.WriteLine("Press anykey to return to the Staff Menu: ");
                Console.ReadLine();
                Console.Clear();
                GetMenu(aMember);
            }
            else if (MemOption == 4) // display all tool that the member is renting
            {
                Console.Clear();
                toolLibrarySystem.displayBorrowingTools(aMember);
                Console.WriteLine("Press anykey to return to the Staff Menu: ");
                Console.ReadLine();
                GetMenu(aMember);
            } 
            else if (MemOption == 5) // display top 3 most tool that most frequently rented
            {
                Console.Clear();
                toolLibrarySystem.displayTopTHree();
                Console.WriteLine("Press anykey to return to the Staff Menu: ");
                Console.ReadLine();
                GetMenu(aMember);
            }
            else if (MemOption == 0) //get back to main menu
            {
                mainMenu.GetMenu();
            }
        }
    }
}
