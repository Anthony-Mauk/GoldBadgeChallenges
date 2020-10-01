using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claim
{
    public class ClaimRepository
    {
        protected readonly List<KClaim> _claimDirectory = new List<KClaim>();
        //CRUD - Create Read Update Delete
        //Create the claim
        public bool AddClaimToDirectory(KClaim content)
        {
            int startingCount = _claimDirectory.Count;
            _claimDirectory.Add(content);
            bool wasAdded = (_claimDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        //Read all claims
        public List<KClaim> GetClaims()
        {
            return _claimDirectory;
        }
        public KClaim GetClaimByID(string id)
        {
            foreach(KClaim singleClaim in _claimDirectory)
            {
                if(singleClaim.ClaimID.ToLower() == id.ToLower())
                {
                    return singleClaim;
                }
            }
            return null;
        }
        //Update 
        //We're not updating any claims
      
        //Delete
        //We're not deleting, we're dequeing RemoveAt(0).

    }
}
