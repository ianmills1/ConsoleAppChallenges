using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge_Repository
{
    public enum ClaimCategory { Car = 1, Home, Theft}

    public class Claim
    {
        public Claim(int claimID, ClaimCategory category, string description, float claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            Category = category;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = (dateOfClaim - dateOfIncident).Days <= 30;
        }

        public Claim()
        {

        }

        public int ClaimID { get; set; }
        public ClaimCategory Category { get; set; }
        public string Description { get; set; }
        public float ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }
    }
}