using System;
using System.Collections.Generic;
using System.Text;
using assignmnet_301.User;
namespace assignmnet_301.BSTreeClass
{
	public class BTreeNode
	{
		private Member member; // value
		private BTreeNode lchild; // reference to its left child 
		private BTreeNode rchild; // reference to its right child

		public BTreeNode(Member aMember)
		{
			this.member = aMember;
			lchild = null;
			rchild = null;
		}
		public Member Member
		{
			get { return member; }
			set { member = value; }
		}
		public string Print
        {
			get { return member.ToString(); }
        }
		public BTreeNode LChild
		{
			get { return lchild; }
			set { lchild = value; }
		}

		public BTreeNode RChild
		{
			get { return rchild; }
			set { rchild = value; }
		}

	}


	public class BSTree : BSTreeInterface
	{
		private Stack<Member> MemberList = new Stack<Member>();
		private BTreeNode root;
		public BSTree()
		{
			root = null;
		}

		public bool IsEmpty()
		{
			return root == null;
		}

		public bool Search(Member aMember)
		{
			return Search(aMember, root);
		}

		private bool Search(Member aMember, BTreeNode r)
		{
			if (r != null)
			{
				if (aMember.CompareTo(r.Member) == 0)
					return true;
				else
					if (aMember.CompareTo(r.Member) < 0)
					return Search(aMember, r.LChild);
				else
					return Search(aMember, r.RChild);
			}
			else
				return false;
		}

		public void Insert(Member aMember)
		{
			if (root == null)
				root = new BTreeNode(aMember);
			else
				Insert(aMember, root);
		}

		// pre: ptr != null
		// post: item is inserted to the binary search tree rooted at ptr
		private void Insert(Member aMember, BTreeNode ptr)
		{
			if (aMember.CompareTo(ptr.Member) < 0)
			{
				if (ptr.LChild == null)
					ptr.LChild = new BTreeNode(aMember);
				else
					Insert(aMember, ptr.LChild);
			}
			else
			{
				if (ptr.RChild == null)
					ptr.RChild = new BTreeNode(aMember);
				else
					Insert(aMember, ptr.RChild);
			}
		}

		// there are three cases to consider:
		// 1. the node to be deleted is a leaf
		// 2. the node to be deleted has only one child 
		// 3. the node to be deleted has both left and right children
		public void Delete(Member aMember)
		{
			// search for item and its parent
			BTreeNode ptr = root; // search reference
			BTreeNode parent = null; // parent of ptr
			while ((ptr != null) && (aMember.CompareTo(ptr.Member) != 0))
			{
				parent = ptr;
				if (aMember.CompareTo(ptr.Member) < 0) // move to the left child of ptr
					ptr = ptr.LChild;
				else
					ptr = ptr.RChild;
			}

			if (ptr != null) // if the search was successful
			{
				// case 3: item has two children
				if ((ptr.LChild != null) && (ptr.RChild != null))
				{
					// find the right-most node in left subtree of ptr
					if (ptr.LChild.RChild == null) // a special case: the right subtree of ptr.LChild is empty
					{
						ptr.Member = ptr.LChild.Member;
						ptr.LChild = ptr.LChild.LChild;
					}
					else
					{
						BTreeNode p = ptr.LChild;
						BTreeNode pp = ptr; // parent of p
						while (p.RChild != null)
						{
							pp = p;
							p = p.RChild;
						}
						// copy the item at p to ptr
						ptr.Member = p.Member;
						pp.RChild = p.LChild;
					}
				}
				else // cases 1 & 2: item has no or only one child
				{
					BTreeNode c;
					if (ptr.LChild != null)
						c = ptr.LChild;
					else
						c = ptr.RChild;

					// remove node ptr
					if (ptr == root) //need to change root
						root = c;
					else
					{
						if (ptr == parent.LChild)
							parent.LChild = c;
						else
							parent.RChild = c;
					}
				}

			}
		}

        public Stack<Member> InOrderTraverse()
		{
			MemberList = new Stack<Member>();			
			InOrderTraverse(root);
			return MemberList;
		}

		private void InOrderTraverse(BTreeNode root)
		{
			
			if (root != null)
			{
				if (root.LChild != null)
					InOrderTraverse(root.LChild);
				MemberList.Push(root.Member);
				if (root.RChild != null)
					InOrderTraverse(root.LChild);
			}
		}

		public void Clear()
		{
			root = null;
		}
	
	}
}
