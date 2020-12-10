using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_repo
{
    public enum TypeOfClaim { Car, Home, Theft }
    public class Claim
    {
        private int TimeLimitInDays = 60;
        public int ClaimId { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateofIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        // change IsValid get to return DateOfIncident - DateOfClaim < TimeLimit
        public bool IsValid { get { return (DateOfClaim - DateofIncident).TotalDays < TimeLimitInDays; } }

        public Claim() { }
        public Claim(int claimId,  TypeOfClaim claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimId = claimId;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateofIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
        public Claim(TypeOfClaim claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateofIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}
