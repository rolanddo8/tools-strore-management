using System;
using System.Collections.Generic;
using System.Text;
using assignmnet_301.BSTreeClass;

namespace assignmnet_301.User
{
    public class MemberCollection : iMemberCollection
    {
        //the private fields of class
        private BSTree memberCollection ;
        private Member[] result;

        //Contructor
        public MemberCollection()
        {
            memberCollection = new BSTree();
        }
        /// <summary>
        /// get and set number of member in collection
        /// </summary>
        public int Number
        {
            get;
            set;
        }   
        /// <summary>
        /// add the new member to member collection
        /// </summary>
        /// <param name="aMember">a member</param>
        public void add(Member aMember)
        {
            memberCollection.Insert(aMember);
            Number++;
        }
        /// <summary>
        /// delete a memeber from member collection
        /// </summary>
        /// <param name="aMember">a member</param>
        public void delete(Member aMember)
        {
            memberCollection.Delete(aMember);
            Number--;
        }
        /// <summary>
        /// search member in collection
        /// </summary>
        /// <param name="aMember">a member</param>
        /// <returns>true if the collection has member, false otherwise</returns>
        public Boolean search(Member aMember)
        {
            return memberCollection.Search(aMember);
        }
        /// <summary>
        /// reutrn the array of member list in member colelction by in order traverse method
        /// </summary>
        /// <returns><the array of member list in member colelction/returns>
        public Member[] toArray()
        {
            result = memberCollection.InOrderTraverse().ToArray();
            return result ;
        }
       
    }
}
