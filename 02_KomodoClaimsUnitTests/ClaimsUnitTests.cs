using _02_KomodoClaimsRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_KomodoClaimsUnitTests
{
    [TestClass]
    public class ClaimsUnitTests
    {
        private ClaimRepo _claimQueue;        

        [TestInitialize]
        public void ClaimsTestsArrange()
        {
            _claimQueue = new ClaimRepo();
            var claim1 = new Claim(TypeOfClaim.Car, "Car accident on 465.", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            var claim2 = new Claim(TypeOfClaim.Home, "House fire in kitchen.", 4000.00, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            
            _claimQueue.AddClaimToQueue(claim1);
            _claimQueue.AddClaimToQueue(claim2);        
        }
        [TestMethod]
        public void TestForAddingClaimToQ()
        {
            var claim3 = new Claim(TypeOfClaim.Theft, "Stolen pancakes.", 4.00, new DateTime(2018, 4, 27), new DateTime(2018, 4, 27));

            _claimQueue.AddClaimToQueue(claim3);

            Queue<Claim> claimQueue = _claimQueue.GetAllClaims();        

            bool IDisEqual = false;
            foreach (Claim claim in claimQueue)
            {
                if (claim.ClaimID == claim3.ClaimID)
                {
                    IDisEqual = true;
                    break;
                }
            }
            Assert.IsTrue(IDisEqual);
        }
        [TestMethod]
        public void TestForGettingAllClaims()
        {
            Queue<Claim> queueFromRepo = _claimQueue.GetAllClaims();
            Assert.IsNotNull(queueFromRepo);
        }
        [TestMethod]
        public void TestForGetNextClaim()
        {
            Claim nextClaim = _claimQueue.GetNextClaim();

            Assert.IsNotNull(nextClaim);
        }
        [TestMethod]
        public void TestForRemovingClaim()
        {
            int starting = _claimQueue.GetAllClaims().Count;
            _claimQueue.RemoveClaimFromQueue();
            int ending = _claimQueue.GetAllClaims().Count;

            Assert.AreNotEqual(starting, ending);
        }
    }
}
