using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsClasses
{
    //Queue<Claim> claims = new Queue<Claim>();
    public enum ClaimType { Car, Home, Theft }
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                
                DateTime expirationDate = DateOfIncident.AddDays(30);
                bool boolResult = (DateOfClaim < expirationDate) ? true : false;
                return boolResult;
         
            }
        }
        public Claim()
        {

        }
        public Claim(int claimID, ClaimType typeOfClaim, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim) //bool isValid)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            //IsValid = isValid;
        }
    }
}
