using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claim
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
    public class KClaim //create claim class
    {// properties
        public string ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string ClaimDesription { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        // need to test to get no set because derived
        // Komodo allows an insurance claim to be made up to 30 days 
        //after an incident took place.If the claim is not in the proper time limit, it is not valid.
        //constructors
        public KClaim() { } //empty constructor
        //create overloaded constructor
        public KClaim(string claimID, ClaimType typeOfClaim, string claimDescription, double claimAmount
            ,DateTime dateOfIncident, DateTime dateOfClaim, bool isValid) //overloaded constructor
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            ClaimDesription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;

        }

    }
}
