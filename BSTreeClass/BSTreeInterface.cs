using System;
using System.Collections.Generic;
using System.Text;
using assignmnet_301.User;


namespace assignmnet_301.BSTreeClass
{
	public interface BSTreeInterface
	{
		// pre: true
		// post: return true if the binary tree is empty; otherwise, return false.
		bool IsEmpty();

		// pre: true
		// post: item is added to the binary search tree
		void Insert(Member aMember);

		// pre: true
		// post: an occurrence of item is removed from the binary search tree 
		//		 if item is in the binary search tree
		void Delete(Member aMember);

		// pre: true
		// post: return true if item is in the binary search true;
		//	     otherwise, return false.
		bool Search(Member aMember);


		// pre: true
		// post: all the nodes in the binary tree are visited once and only once in in-order
		Stack<Member> InOrderTraverse();


		// pre: true
		// post: all the nodes in the binary tree are removed and the binary tree becomes empty
		void Clear();
	}
}
