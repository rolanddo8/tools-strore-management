using assignmnet_301.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace assignmnet_301
{
    //The specification of ToolCollection ADT, which is used to store and manipulate a collection of tools
    public class ToolCollection : iToolCollection
    {
        //private fields of class
        private int numTool = 0;
        private static Tool[] toolCollection = new Tool[100];

        // get the number of the types of tools in the community library
        public int Number 
        {
            get { return numTool; }
            set { numTool = value; }
        }
        /// <summary>
        /// add a tool to tool collection
        /// </summary>
        /// <param name="aTool">a tool</param>
        public void add(Tool aTool)
        {
            toolCollection[Number++] = aTool;
        }
        /// <summary>
        /// delete a tool from tool collection
        /// </summary>
        /// <param name="aTool"></param>
        public void delete(Tool aTool)
        {
            for (int i = 0; i < numTool; i++)
            {
                if (aTool.CompareTool(toolCollection[i]) == true)
                {
                    toolCollection = toolCollection.Where(e => e != aTool).ToArray();
                }
            }
        }
        /// <summary>
        /// search the tool form tool collection
        /// </summary>
        /// <param name="aTool">a tool</param>
        //private StaffMenu staffMenu = new StaffMenu();
        /// <returns>true if the tool is in tool collection, otherwise return false</returns>
         public Boolean search(Tool aTool)
            {
           for (int i = 0; i < numTool; i++)
                {
                    if (aTool.Name.CompareTo(toolCollection[i].Name) == 0)
                    {
                        return true;
                    }
                }
                return false;
            }
        /// <summary>
        /// return tool colleciton in array of tool
        /// </summary>
        /// <returns>array of tool</returns>
        public Tool[] toArray()
        {
            return toolCollection;        
        } // output the tools in this tool collection to an array of iTool

    }
}
