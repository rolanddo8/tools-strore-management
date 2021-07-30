using System;
using System.Collections.Generic;
using System.Text;

namespace assignmnet_301.BSTreeClass
{
    public class BSTNode
    {
        char item;         //data item
        BSTNode lChild; //reference to left child (less than this node)
        BSTNode rChild; //reference to right child (greater than this node)

        //Constructor
        public BSTNode(char ch)
        {
            item = ch;
        }

        //Properties
        public char Item
        {
            get { return item; }
            set { item = value; }
        }

        public BSTNode Left
        {
            get { return lChild; }
            set { lChild = value; }
        }

        public BSTNode Right
        {
            get { return rChild; }
            set { rChild = value; }
        }
    }
   
}
