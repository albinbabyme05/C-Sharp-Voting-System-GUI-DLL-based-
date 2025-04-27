using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting_System
{
    public class Admin : User
{
        private Guid AdminId;

        private Dictionary<Guid, Candidate> CandidateDictionary;

        public Admin(string userName, string userPassword) : base(userName, userPassword)
        {
            CandidateDictionary = new Dictionary<Guid, Candidate>();

            AdminId = Guid.NewGuid();


        }

        
        public void AddCandidate(Candidate candidate)
        {

            if (!CandidateDictionary.ContainsKey(candidate.GetCandidateID()))
            {
                CandidateDictionary.Add(candidate.GetCandidateID(), candidate);
            }
            else
            {
                Console.WriteLine("Candidate already exists.");
            }


            CandidateDictionary.Add(candidate.GetCandidateID(), candidate);

        }

        public void RemoveCandidate(Guid candidateId)
        {
            if (CandidateDictionary.ContainsKey(candidateId))
            {
                CandidateDictionary.Remove(candidateId);

                Console.WriteLine("Candidate removed successfully.");
            }
            else
            {
                Console.WriteLine("Candidate ID not found.");
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

            Console.WriteLine($"Welcome, Admin {AdminId}! Accessing Admin Dashboard...");


        }

        
    }
}
