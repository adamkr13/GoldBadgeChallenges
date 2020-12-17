using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaimsRepo
{
    public class ClaimRepo
    {
        private readonly Queue<Claim> _claimQueue = new Queue<Claim>();
        private int _claimIdCounter = 0;

        public void AddClaimToQueue(Claim claim)
        {
            claim.ClaimID = _claimIdCounter + 1;
            _claimQueue.Enqueue(claim);
            _claimIdCounter++;
        }

        public Queue<Claim> GetAllClaims()
        {
            return _claimQueue;
        }

        //public Claim GetClaimById (int claimID)
        //{
        //    foreach (Claim claim in _claimQueue)
        //    {
        //        if (claim.ClaimID == claimID)
        //        {
        //            return claim;
        //        }
        //    }
        //    return null;                
        //}

        public Claim GetNextClaim()
        {
            return _claimQueue.Peek();
        }
        
        public void RemoveClaimFromQueue()
        {
            _claimQueue.Dequeue();
        }
    }
}
