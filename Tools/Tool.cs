using System.Collections.Generic;
using System;
using assignmnet_301.User;

namespace assignmnet_301.Tools
{
    
    //The specification of Tool ADT
    public class Tool : iTool
    {
        //private fields
        private string name;
        private int quantity;
        private int noBorrowings;
        private int avaiableQuantity;
        private MemberCollection Borrowers = new MemberCollection();

        //Contructor
        public Tool(string name, int quantity, int availableQuantity, int noBorrowings, MemberCollection getBorrowers)
        {
            this.name = name;
            this.quantity = quantity;
            this.avaiableQuantity = availableQuantity;
            this.noBorrowings = noBorrowings;
            this.Borrowers = getBorrowers;
        }
        public string Name // get and set the name of this tool
        {
            get { return name; }
            set { name = value;  }
        }

        public int Quantity //get and set the quantity of this tool
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public int AvailableQuantity //get and set the quantity of this tool currently available to lend
        {
            get { return avaiableQuantity; }
            set { avaiableQuantity = quantity - noBorrowings; }
        }

        public int NoBorrowings //get and set the number of times that this tool has been borrowed
        {
            get { return noBorrowings; }
            set { noBorrowings = value; }
        }
        /// <summary>
        /// Get the members borrowing the tool
        /// </summary>
        public MemberCollection GetBorrowers
        {
            get { return Borrowers; }
        }
        /// <summary>
        /// Compare two tool
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true if two tools are the same, false otherwise</returns>
        public bool CompareTool(Object obj)
        {
            Tool another = (Tool)obj;
            if (this.name.CompareTo(another.name) == 0)
            {
                return true;
            }
            return false;            
        }
        /// <summary>
        /// display tool in the string type
        /// </summary>
        /// <returns>string type of the tool</returns>
        public override string ToString()
        {
            return "Name='" + this.Name + '\'' +
               ", Quantity='" + this.Quantity + '\'' +
               ", Available Quantity='" + this.AvailableQuantity + '\'' +
               ", Number of Borrowings='" + this.NoBorrowings + '\'';
        }
        /// <summary>
        /// add the member who is borrowing the tool
        /// </summary>
        /// <param name="aMember">a member</param>
        public void addBorrower(Member aMember)
        {
            Borrowers.add(aMember);
        }
        /// <summary>
        /// delete the member that returned the tool
        /// </summary>
        /// <param name="aMember">a member</param>
        public void deleteBorrower(Member aMember)
        {
            Borrowers.delete(aMember);
        }
    }

}
