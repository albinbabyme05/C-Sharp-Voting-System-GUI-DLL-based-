using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Voting_System
{
    public class Candidate
    {
        private Guid CandidateId;
        public string Name;
        public string Party;
        private int VoteCount;

        public Candidate(string name, string party )

        {
            Name = name;
            CandidateId = Guid.NewGuid();
            Party = party;
            VoteCount = 0;
        }

        public int GetVotecount() => VoteCount;
        public Guid GetCandidateID() => CandidateId;
        public void SetVoteCount() { VoteCount += 1;  }

    } 
}
