using assignmnet_301.User;
using System;
using assignmnet_301.Menu;
using System.Collections.Generic;
using System.Text;
namespace assignmnet_301.Tools
{
    class ToolLibrarySystem : iToolLibrarySystem
    {
        /// <summary>
        /// //private fields of class
        /// </summary>
        private ToolCollection[][] ToolLibrary = new ToolCollection[9][];
        private static MemberCollection MemberCollectionSystem = new MemberCollection();
        private String[][] Types = new String[9][];
        private String[] Categories = new String[9];
        private MainMenu mainMenu = new MainMenu();
        private Tool toolIndex;
        private Member aMember;
        private string memberFirstName;
        private string memberLastName;
        private string memberPin;
        //Constructor
        public ToolLibrarySystem()
        {
            Categories = new string[] { "Gardening tools", "Flooring tools", "Fencing tools", "Measuring tools", "Cleaning tools", "Painting tools", "Electronic tools", "Electricity tools", "Automotive tools" };
            Types[0] = new string[] { "Line Trimmers", "Lawn Mowers", "Gardening Hand Tools", "Wheelbarrows", "Garden Power Tools" };
            Types[1] = new string[] { "Scrapers", "Floor Lasers", "Floor Levelling Tools", "Floor Levelling Materials", "Floor Hand Tools", "Tiling Tools" };
            Types[2] = new string[] { "Fencing Hand Tools", "Electric Fencing", "Steel Fencing Tools", "Power Tools", "Fencing Accessories" };
            Types[3] = new string[] { "Distance Tools", "Laser Measurer", "Measuring Jugs", "Temperature & Humidity Tools", "Levelling Tools", "Markers" };
            Types[4] = new string[] { "Draining", "Car Cleaning", "Vacuum", "Pressure Cleaners", "Pool Cleaning", "Floor Cleaning" };
            Types[5] = new string[] { "Sanding Tools", "Brushes, Rollers", "Paint Removal Tools", "Paint Scrapers, Sprayers" };
            Types[6] = new string[] { "Voltage Tester", "Oscilloscopes", "Thermal Imaging", "Data Test Tool", "Insulation Testers" };
            Types[7] = new string[] { "Test Equipment", "Safety Equipment", "Basic Hand tools", "Circuit Protection", "Cable Tools" };
            Types[8] = new string[] { "Jacks", "Air Compressors", "Battery Chargers", "Socket Tools", "Braking, Drivetrain" };


            for (int i = 0; i < Types.Length; i++)
            {
                ToolLibrary[i] = new ToolCollection[Types[i].Length];
                for (int j = 0; j < Types[i].Length; j++)
                {
                    ToolLibrary[i][j] = new ToolCollection();
                }
            }
        }
        //The Functions below are decleared to develop the program flow
        /// <summary>
        /// get the index of category tool
        /// </summary>
        /// <returns>get the index of category</returns>
        public int GetCategories()
        {
            for (int i = 0; i < Categories.Length; i++)
            {
                Console.WriteLine("\n" + i + "." + Categories[i]);
            }
            int option = (int)mainMenu.GetUserNum(prompt: "\n Select an category for the tool: ", min: 0, max: 6, wholeNumber: true);
            return option;
        }
        /// <summary>
        /// get the index of type tool
        /// </summary>
        /// <param name="index"> given the index of tool category</param>
        /// <returns>the index of tool type</returns>
        public int GetTypes(int index)
        {
            for (int i = 0; i < Types[index].Length; i++)
            {
                Console.WriteLine("\n" + i + "." + Types[index][i]);
            }
            int option = (int)mainMenu.GetUserNum(prompt: "\n Select a tool type for the tool: ", min: 0, max: 9, wholeNumber: true);
            return option;
        }
        /// <summary>
        /// print the table of tools
        /// </summary>
        /// <param name="categoriesIndex">given the index of tool category</param>
        /// <param name="typesIndex">given the index of tool type</param>
        /// <returns> the table of tools</returns>
        public Boolean PrintTools(int categoriesIndex, int typesIndex)
        {
            Boolean result = false;
            for (int i = 0; i < Types.Length; i++)
            {
                if (i == categoriesIndex)
                {
                    for (int j = 0; j < Types[i].Length; j++)
                    {
                        if (j == typesIndex)
                        {
                            if (ToolLibrary[i][j].Number == 0)
                            {
                                Console.WriteLine("No tools are available for the selected tool type!");
                                result = false;
                            }
                            else
                            {
                                for (int y = 0; y < ToolLibrary[i][j].Number; y++)
                                {
                                    Console.WriteLine("======================================================== Tools table: ======================================================" +
                                                        "\n============================================================================================================================" +
                                                        "\n||numberID: {0,10}||Name: {1,10}|| Quantity: {2,10}|| AvailableQuantity {3,10}|| NoBorrowings: {4,10}||" +
                                                        "\n============================================================================================================================",
                                                        y,
                                                        ToolLibrary[i][j].toArray()[y].Name,
                                                        ToolLibrary[i][j].toArray()[y].Quantity,
                                                        ToolLibrary[i][j].toArray()[y].AvailableQuantity,
                                                        ToolLibrary[i][j].toArray()[y].NoBorrowings
                                                        );
                                    result = true;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// get the tool that the staff want to add pieces and the quantity,then add the quantity to this tool
        /// </summary>
        /// <param name="aTool">a tool to add pieces</param>
        public void addPiecesTool(Tool aTool) {
            int categoryIndex = GetCategories();
            Console.Clear();
            int typeIndex = GetTypes(categoryIndex);
            if (PrintTools(categoryIndex, typeIndex) == true)
            {
                int toolOption = (int)mainMenu.GetUserNum(prompt: "\n Select tool numberID to add: ", min: 0, wholeNumber: true);
                toolIndex = ToolLibrary[categoryIndex][typeIndex].toArray()[toolOption];
                int quantity = (int)mainMenu.GetUserNum(prompt: "\n Input the quantity for the tool: ", min: 0, wholeNumber: true);
                add(toolIndex, quantity);
            }
        }
        /// <summary>
        /// remove pieces of tool 
        /// </summary>
        /// <param name="aTool">a tool that remove pieces</param>
        public void removePiecesTool(Tool aTool)
        {
            int categoryIndex = GetCategories();
            Console.Clear();
            int typeIndex = GetTypes(categoryIndex);
            if (PrintTools(categoryIndex, typeIndex) == true)
            {
                int toolOption = (int)mainMenu.GetUserNum(prompt: "\n Select tool numberID option: ", min: 0, wholeNumber: true);
                toolIndex = ToolLibrary[categoryIndex][typeIndex].toArray()[toolOption];
                int quantity = (int)mainMenu.GetUserNum(prompt: "\n Input the quantity for the tool: ", min: 0, wholeNumber: true);
                delete(toolIndex, quantity);
            }
        }
        /// <summary>
        /// add the new tool to the tool system collection
        /// </summary>
        /// <param name="aTool">name of the tool that add to tool system collection</param>
        public void addToolHandle(Tool aTool)
        {
            int categoryIndex = GetCategories();
            Console.Clear();
            int typeIndex = GetTypes(categoryIndex);
            Console.Clear(); 
            PrintTools(categoryIndex, typeIndex);
            add(aTool, categoryIndex, typeIndex);
            Console.Clear();
            PrintTools(categoryIndex, typeIndex);
        }
        /// <summary>
        /// print all member in the memeber system collection
        /// </summary>
        /// <returns>the list of memeber in system if the system has, otherwise return error message</returns>
        public Boolean PrintMember()
        {
            Member[] array = MemberCollectionSystem.toArray();
            Boolean result = false;
            if (array.Length != 0)
            {
               foreach (Member aMember in array)
                {
                    Console.WriteLine(aMember.ToString());
                }
                result = true;
            }    
           else
            {
                Console.WriteLine("No member register yet!");
                result = false;
            }
            return result;
        }
        /// <summary>
        /// get all needed information of member to register a new memnber 
        /// </summary>
        public void addMemberHanle()
        {
            aMember = new Member("", "", "", "");
            Console.WriteLine("First Name: ");
            string fname, lname, phone, pin ;
            fname = Console.ReadLine();
            aMember.FirstName = fname;
            Console.WriteLine("Last Name: ");
            lname = Console.ReadLine();
            aMember.LastName = lname;
            Console.WriteLine("Your contact number: ");
            phone = Console.ReadLine();
            aMember.ContactNumber = phone;
            Console.WriteLine("Enter your password: ");
            pin = Console.ReadLine();
            aMember.PIN = pin;
            add(aMember);
            PrintMember();
        }
        /// <summary>
        /// remove the member in the member system collection
        /// </summary>
        /// <param name="aMember">the member that want to delete</param>
        public void removeMemberHanle(Member aMember)
        {
            if (PrintMember() == true)
            {
                int option = (int)mainMenu.GetUserNum(prompt: "\n Select member to delete (start from 0): ", min: 0, wholeNumber: true);
                aMember = MemberCollectionSystem.toArray()[option];
                delete(aMember);
            }
        }
        /// <summary>
        /// get the contact number of given member
        /// </summary>
        /// <param name="aMember">a member that want to get contact number</param>
        public void findContactNumber(Member aMember)
            {
                 if (PrintMember() == true)
                    {
                        int option = (int)mainMenu.GetUserNum(prompt: "\n Select an option: ", min: 0, max: MemberCollectionSystem.toArray().Length - 1, wholeNumber: true);
                        aMember = MemberCollectionSystem.toArray()[option];
                        Console.WriteLine("Number contact: " + aMember.ContactNumber);
                    }
            }
        /// <summary>
        /// borrow a tool in library for a member
        /// </summary>
        /// <param name="aMember">member that want to borrow the tool</param>
        public void borrowToolHandle(Member aMember)
        {
            displayTools();
            Console.WriteLine("Select the tool to borrow: ");
            int option = (int)mainMenu.GetUserNum(prompt: "\n Select an option: ", min: 0, wholeNumber: true);
        }
        /// <summary>
        /// reutnr the tool from the member
        /// </summary>
        /// <param name="aMember">a member that return a tool</param>
        public void returnToolHandle(Member aMember)
        {
            displayBorrowingTools(aMember);
            int categoryIndex = GetCategories();
            Console.Clear();
            int typeIndex = GetTypes(categoryIndex); 
            int option = (int)mainMenu.GetUserNum(prompt: "\n Select an option: ", min: 0, wholeNumber: true);
            Tool toolReturn = ToolLibrary[categoryIndex][typeIndex].toArray()[option];
            returnTool(aMember, toolReturn);
        }
        /// <summary>
        /// check if the member already register and give the correct name and password
        /// </summary>
        /// <param name="aMember">a member to check valid</param>
        /// <returns></returns>
        public bool ValidUserHandle(Member aMember)
        {

            Console.WriteLine("Enter your member First Name: ");
            memberFirstName = Console.ReadLine();
            Console.WriteLine("Enter your member Last Name: ");
            memberLastName = Console.ReadLine();
            Console.WriteLine("Enter your account password: ");
            memberPin = Console.ReadLine();
            foreach (Member member in MemberCollectionSystem.toArray())
            {
                if(member.FirstName + member.LastName == memberFirstName + memberLastName)
                {
                    aMember = member;
                }
            }
            if (MemberCollectionSystem.search(aMember) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// get member from member collection system to login
        /// </summary>
        /// <returns></returns>
        public Member getUserHandle()
        {
            foreach (Member member in MemberCollectionSystem.toArray())
            {
                if (member.FirstName + member.LastName == memberFirstName + memberLastName)
                {
                    aMember = member;
                }
            }
            if (MemberCollectionSystem.search(aMember) == true)
            {
                Console.WriteLine("Name and Password is correct");
                Console.ReadLine();
                return aMember;

            }
            else
            {
                Console.WriteLine("Name or Password is incorrect");
            }
            return aMember;
        }

        ///the functions below are implement from the interface class
        
        /// <summary>                                                                   
        /// add a tool to system
        /// </summary>
        /// <param name="aTool">the tool to add</param>
        /// <param name="categoriesIndex">the index category of this tool</param>
        /// <param name="typesIndex">the index types of this tool</param>
        public void add(Tool aTool, int categoriesIndex, int typesIndex)
        {
            Console.WriteLine("Write a name for the tool: ");
            string name = Console.ReadLine();
            aTool.Name = name;
            ToolLibrary[categoriesIndex][typesIndex].add(aTool);

        }
        /// <summary>
        /// add the quantity to the existing tool
        /// </summary>
        /// <param name="aTool"> a existing tool that want to add quantity</param>
        /// <param name="quantity">number of quantity</param>
        public void add(Tool aTool, int quantity)
        {
                int ToolQuantity = aTool.Quantity;
                aTool.Quantity = ToolQuantity + quantity;
                int availTool = aTool.AvailableQuantity;
                aTool.AvailableQuantity = availTool + quantity;
                Console.WriteLine("Quantity added: " + quantity);
        }
        /// <summary>
        /// add member to member system collection
        /// </summary>
        /// <param name="aMember">a member</param>
        public void add(Member aMember)
        {
            MemberCollectionSystem.add(aMember);
            Console.WriteLine("The member has been added successfully");
        }
        /// <summary>
        /// add a tool to borrowing list of member
        /// </summary>
        /// <param name="aMember">member that borrow the tool</param>
        /// <param name="aTool">the borrowing tool</param>
        public void borrowTool(Member aMember, Tool aTool)
        {
            aMember.addTool(aTool);
            Console.WriteLine("The member has borrowed the tool successfully");
        }
        /// <summary>
        ///delete the tool that has already added 
        /// </summary>
        /// <param name="aTool">the tool</param>
        /// <param name="categoriesIndex">the index of tool category</param>
        /// <param name="typesIndex">the index of tool type</param>
        public void delete(Tool aTool, int categoriesIndex, int typesIndex)
        {
                ToolLibrary[categoriesIndex][typesIndex].delete(aTool);
                Console.WriteLine("The tool has been deleted successfully");
        }
        /// <summary>
        /// delete a piecies of tool
        /// </summary>
        /// <param name="aTool">the tool to delete quantity</param>
        /// <param name="quantity">the number of quantity to delete</param>
        public void delete(Tool aTool, int quantity)
        {
            aTool.Quantity -= quantity;
            aTool.AvailableQuantity -= quantity;
            Console.WriteLine("Quantity delelted successfully");
        }
        /// <summary>
        /// delete the member from member system collection
        /// </summary>
        /// <param name="aMember">a member to delete</param>
        public void delete(Member aMember)
        {
            MemberCollectionSystem.delete(aMember);
            Console.WriteLine("The member has been deleted successfully ");
        }
        /// <summary>
        /// display all the tool that the member is borrowing
        /// </summary>
        /// <param name="aMember">a member want to display</param>
        public void displayBorrowingTools(Member aMember)
        {
            string[] Toollist = aMember.Tools; 
            for (int i = 0; i < Toollist.Length; i++)
            {
                Console.WriteLine(Toollist[i]);
            }
        }
        /// <summary>
        /// display all the tool added in tool system collection
        /// </summary>
        public void displayTools()
        {
            int categoryIndex = GetCategories();
            Console.Clear();
            int typeIndex = GetTypes(categoryIndex);
            Console.Clear();
            PrintTools(categoryIndex, typeIndex);
        }
        /// <summary>
        /// display top three tools that most frequently borrowed by member, using the heap sort from practical materials
        /// </summary>
        public void displayTopTHree()
        {
            //This Heap Sort algorithm below is reference from practical materials.
            // Convert a complete binary tree into a heap
            static void HeapBottomUp(Tool[] tools)
            {
                int arrayLength = tools.Length;
                for (int i = (arrayLength - 1) / 2; i >= 0; i--)
                {
                    int k = i;
                    Tool v = tools[i];
                    bool heap = false;
                    while ((!heap) && ((2 * k + 1) <= (arrayLength - 1)))
                    {
                        int j = 2 * k + 1;  //the left child of k
                        if (j < (arrayLength - 1))   //k has two children
                            if (tools[j].NoBorrowings < tools[j + 1].NoBorrowings)
                                j = j + 1;  //j is the larger child of k
                        if (v.NoBorrowings >= tools[j].NoBorrowings)
                            heap = true;
                        else
                        {
                            tools[k] = tools[j];
                            k = j;
                        }
                    }
                    tools[k] = v;
                }
            }

            // sort the elements in an array 
            static void HeapSort(Tool[] tools)
            {
                //Use the HeapBottomUp procedure to convert the array, data, into a heap
                HeapBottomUp(tools);


                //repeatly remove the maximum key from the heap and then rebuild the heap
                for (int i = 0; i <= tools.Length - 2; i++)
                {
                    MaxKeyDelete(tools, tools.Length - i);
                }
            }

            //delete the maximum key and rebuild the heap
            static void MaxKeyDelete(Tool[] tools, int size)
            {
                //1. Exchange the root’s key with the last key K of the heap;
                Tool temp = tools[0];
                tools[0] = tools[size - 1];
                tools[size - 1] = temp;

                //2. Decrease the heap’s size by 1;
                int n = size - 1;

                //3. “Heapify” the complete binary tree.
                bool heap = false;
                int k = 0;
                Tool v = tools[0];
                while ((!heap) && ((2 * k + 1) <= (n - 1)))
                {
                    int j = 2 * k + 1; //the left child of k
                    if (j < (n - 1))   //k has two children
                        if (tools[j].NoBorrowings < tools[j + 1].NoBorrowings)
                            j = j + 1;  //j is the larger child of k
                    if (v.NoBorrowings >= tools[j].NoBorrowings)
                        heap = true;
                    else
                    {
                        tools[k] = tools[j];
                        k = j;
                    }
                }
                tools[k] = v;
            }
            //create an array of all the tools currently existed in the library
            ToolCollection top = new ToolCollection();
            for (int i = 0; i < Types.Length; i++)
            {
                for (int j = 0; j < Types[i].Length; j++)
                {
                    for (int y = 0; y < ToolLibrary[i][j].Number; y++)
                    {
                        top.add(ToolLibrary[i][j].toArray()[y]);
                    }
                            
                }
            }
            Tool[] top3 = top.toArray();
            //sort the given array of all available tools in the library (based on its' number of borrows)
            HeapSort(top3);
            //display 3 tools have highest number of borrowers. 
            Console.WriteLine("Top 1" + " " + top3[top3.Length - 1].Name + " || Number of Borrowers: " + top3[top3.Length - 1].NoBorrowings);
            Console.WriteLine("Top 2" + " " + top3[top3.Length - 2].Name + " || Number of Borrowers: " + top3[top3.Length - 2].NoBorrowings);
            Console.WriteLine("Top 3" + " " + top3[top3.Length - 3].Name + " || Number of Borrowers: " + top3[top3.Length - 3].NoBorrowings);
        }
        /// <summary>
        /// get the list of string of the tool that the member is renting
        /// </summary>
        /// <param name="aMember">a member</param>
        /// <returns>string list of tools</returns>
        public string[] listTools(Member aMember)
        {
            return aMember.Tools;
        }
        /// <summary>
        /// return the tool that member has already borrowed
        /// </summary>
        /// <param name="aMember">a member</param>
        /// <param name="aTool">a tool to return</param>
        public void returnTool(Member aMember, Tool aTool)
        {
            aMember.deleteTool(aTool);
        }
    }
}
