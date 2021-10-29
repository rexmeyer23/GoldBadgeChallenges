using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsClasses
{
    public class ClaimRepo
    {
        private readonly Queue<Claim> _claimsQueue = new Queue<Claim>();
        //CRUD
        //CREATE
        public void FileNewClaim(Claim newClaim)
        {

            _claimsQueue.Enqueue(newClaim);
        }
        //READ
        public Queue<Claim> ListClaims()
        {
            return _claimsQueue;
        }
        public Claim PeekFirstClaim()
        {
            return _claimsQueue.Peek();
        }

        //public Claim StringDescription(string description)
        //{
        //    char[] delimiters = new char[] { ' ', '.' };
        //    foreach (var word in description.Split(delimiters)) 
        //    {
        //        Console.WriteLine(word);
        //    }
        //}

        //UPDATE
        //DELETE
        public Claim RemoveClaim()
        {
            return _claimsQueue.Dequeue();
        }
        //HELPER
        //public Claim RetrieveClaimByID(int claimID)
        //{
        //    foreach(Claim claim in _claimsQueue)
        //    {
        //        if(claim.ClaimID == claimID)
        //        {
        //            return claim;
        //        }
        //    }
        //    return null;
        //}
    }
}
