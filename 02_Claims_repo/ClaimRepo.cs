using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_repo
{
    public class ClaimRepo
    {
        public List<Claim> _claims = new List<Claim>();
        private int count = 1;

        // Create
        public bool AddClaim(Claim claim)
        {
            if(claim.ClaimId == 0)
            {
                claim.ClaimId = count;
            }

            int old = _claims.Count;
            
            _claims.Add(claim);
            if (_claims.Count > old)
            {
                count++;
                return true;
            }
            else
            {
                return false;
            }
        }


        // Read
        public Claim GetClaimById(int id)
        {
            foreach(Claim i in _claims)
            {
                if(i.ClaimId == id)
                {
                    return i;
                }
            }
            return null;
        }

        public List<Claim> GetClaims()
        {
            return _claims;
        }

        // Delete
        public bool DeleteClaimById(int id)
        {
            Claim claim = GetClaimById(id);
            if(claim != null)
            {
                return _claims.Remove(claim);
            }
            return false;
        }
    }
}
