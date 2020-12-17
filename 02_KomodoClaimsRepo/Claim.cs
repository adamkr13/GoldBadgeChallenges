using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaimsRepo
{
    public enum TypeOfClaim
    {
        Car = 1,
        Home,
        Theft,
        Other
    }

    public class Claim
    {
        public int ClaimID { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan timeSpan = DateOfClaim - DateOfIncident;
            if (timeSpan.TotalDays <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Claim() { }

        public Claim(TypeOfClaim claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;            
        }
    }
}
