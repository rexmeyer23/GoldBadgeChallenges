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
        public bool FileNewClaim(Claim newClaim)
        {
           int initialCount = _claimsQueue.Count();
            _claimsQueue.Enqueue(newClaim);
            if ( _claimsQueue.Count == initialCount + 1 ) 
            {
                return true;
            }
            return false;
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
