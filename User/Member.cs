using System;
using System.Collections.Generic;
using System.Text;
using assignmnet_301.Tools;
namespace assignmnet_301.User
{
    public class Member : iMember
    {
        //the private fields of class
        private string lastname;
        private string firstname;
        private string contactnumber;
        private string password;
        private ToolCollection tools = new ToolCollection();

        //Contructor
        public Member(string lastname, string firstname, string contactnumber, string password)
        {
            this.lastname = lastname;
            this.firstname = firstname;
            this.contactnumber = contactnumber;
            this.password = password;
        }
        /// <summary>
        /// get and set First Name of member
        /// </summary>
        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }
        /// <summary>
        /// get and set Last Name of member
        /// </summary>
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }
        /// <summary>
        /// get and set contact number of member
        /// </summary>
        public string ContactNumber
        {
            get { return contactnumber; }
            set { contactnumber = value; }
        }
        //get and set password for member
        public string PIN
        {
            get { return password; }
            set { password = value; }
        }
        /// <summary>
        /// Compare 2 member 
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>true if two member are the same, false otherwise</returns>
        public int CompareTo(Object obj)
        {
            Member another = (Member)obj;
            if (this.lastname.CompareTo(another.LastName) < 0)
                return -1;
            else
                    if (this.lastname.CompareTo(another.LastName) == 0)
                return this.firstname.CompareTo(another.FirstName);
            else
                return 1;
        }
        /// <summary>
        /// trafer member to  string type of member 
        /// </summary>
        /// <returns>string type of member</returns>
        public override string ToString()
        {
            return "Member{" + "First Name: '" + this.firstname + '\'' +
                     ", Last Name='" + this.lastname + '\'' +
                     ", Contact Number='" + this.contactnumber + '\'' +
                     ", Password='" + this.password + '\'' +
                     '}';
        }
        /// <summary>
        /// add a tool to that member is borrowing
        /// </summary>
        /// <param name="aTool">a tool</param>
        public void addTool(Tool aTool)
        {
            tools.add(aTool);
        }
        /// <summary>
        /// delete a tool that member has returned
        /// </summary>
        /// <param name="aTool"></param>
        public void deleteTool(Tool aTool)
        {
            tools.delete(aTool);
        }
        /// <summary>
        /// get string list of tools that member is borrowing
        /// </summary>
        public string[] Tools //get a list of tools that this memebr is currently holding
        {
            get 
            {
                String[] result = new String[3];
                Tool[] toolList = tools.toArray();
                for (int i = 0; i < result.Length; i++)
                {
                    if (toolList[i] != null)
                    {
                        result[i] = toolList[i].Name;
                    }
                }
                return result;
            }
        }

    }
}
