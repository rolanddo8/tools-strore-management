using System;
using assignmnet_301.Tools;
using assignmnet_301.User;
using System.Collections.Generic;
using System.Text;

namespace assignmnet_301.Menu
{
    class StaffMenu : Menu
    {
        //fields
        MainMenu mainMenu;
        private Tool aTool;
        private Member aMember;
        private static ToolLibrarySystem toolLibrarySystem = Program.toolLibrarySystem;

        //Contructor
        public StaffMenu()
        {
            mainMenu = new MainMenu();
        }
        //get staff menu
        public void GetMenu()
        {
            Console.WriteLine("===================== Staff MENU =====================");
            Console.WriteLine("1. Add a new tool");
            Console.WriteLine("2. Add a new pieces of an existing tool");
            Console.WriteLine("3. Remove some pieces of a tool");
            Console.WriteLine("4. Register a new member");
            Console.WriteLine("5. Remove a member");
            Console.WriteLine("6. Find a contact number of member");
            Console.WriteLine("0. Return to Main Menu");
            Console.WriteLine("=====================================================");
            Console.WriteLine();
            Console.Write("Please make a selection (1-6, or 0 to return to main menu):");

            double staffMenuOption = mainMenu.GetUserNum(prompt: "\n Select an option: ", min: 0, max: 6, wholeNumber: true);
            
            //the user choose to add a tool
            if (staffMenuOption == 1)
            {
                aTool = new Tool("", 0, 0, 0, null);
                Console.Clear();
                toolLibrarySystem.addToolHandle(aTool);
                Console.WriteLine("Press anykey to return to the Staff Menu: ");
                Console.ReadLine();
                Console.Clear();
                GetMenu();
            }
            else if (staffMenuOption == 2) // a user choose to a new pieces of tool
            {
                Console.Clear();
                toolLibrarySystem.addPiecesTool(aTool);
                Console.WriteLine("Press anykey to return to the Staff Menu: ");
                Console.ReadLine();
                Console.Clear();
                GetMenu();
            }
            else if (staffMenuOption == 3) // a user choose to remove a pieves of tool
            {
                Console.Clear();
                toolLibrarySystem.removePiecesTool(aTool);
                Console.WriteLine("Press anykey to return to the Staff Menu: ");
                Console.ReadLine();
                Console.Clear();
                GetMenu();
            }
            else if (staffMenuOption == 4) // register new member 
            {
                Console.Clear();
                toolLibrarySystem.addMemberHanle();
                Console.WriteLine("Press anykey to return to the Staff Menu: ");
                Console.ReadLine();
                Console.Clear();
                GetMenu();
            }
            else if (staffMenuOption == 5) // delete a member
            {
                Console.Clear();
                toolLibrarySystem.removeMemberHanle(aMember);
                Console.WriteLine("Press anykey to return to the Staff Menu: ");
                Console.ReadLine();
                Console.Clear();
                GetMenu();
            }
            else if (staffMenuOption == 6) // get contact number of member
            {
                Console.Clear();
                toolLibrarySystem.findContactNumber(aMember);
                Console.WriteLine("Press anykey to return to the Staff Menu: ");
                Console.ReadLine();
                Console.Clear();
                GetMenu();
            }    
            else if (staffMenuOption == 0) //get back to main menu
            {
                Console.Clear();
                mainMenu.GetMenu();
            }

        }


    }
}
