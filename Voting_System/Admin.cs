using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting_System
{
    public class Admin : User
    {
        private string AdminId;
        private Dictionary<Guid, Candidate> CandidateDictionary;

        public Admin(string userName, string userPassword) : base(userName, userPassword)
        {
            CandidateDictionary = new Dictionary<Guid, Candidate>();
        }

        
        public void AddCandidate(Candidate candidate)
        {
            CandidateDictionary.Add(candidate.GetCandidateID(), candidate);
        }

        public void RemoveCandidate(Guid candidateId)
        {
            if (CandidateDictionary.ContainsKey(candidateId))
            {
                CandidateDictionary.Remove(candidateId);
            }
            
        }

        public Dictionary<string, int> ViewResult(List<Candidate> candidateList)
        {
            var result = new Dictionary<string, int>();
            foreach (var item in candidateList)
            {
                if (CandidateDictionary.ContainsKey(item.GetCandidateID()))
                {
                    result.Add(item.Name, item.GetVotecount());
                }
               
            }
            return result;
        }
        public override void AccessPortal()
        {
            throw new NotImplementedException();
        }

        
    }
}
