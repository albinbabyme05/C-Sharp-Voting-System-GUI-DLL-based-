using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting_System
{
    public class VotingSystem
    {
        private List<Voter> VotersList;
        private List<Admin> AdminsList;
        private List<Candidate> CandidatesList;

        public VotingSystem()
        {
            VotersList = new List<Voter>();
            AdminsList = new List<Admin>();
            CandidatesList = new List<Candidate>();
        }

        public void RegisterVoters(Voter voter)
        {
            VotersList.Add(voter);
            Console.WriteLine("Voter added to the VotersList in the manager module");

        }

        public void RegisterAdmin(Admin admin)
        {
            AdminsList.Add(admin);
            Console.WriteLine("Admin  added to the Admin list in manager module");
        }

        public User? AuthenticateUser(string userName, string password)
        {
            foreach (var admin in AdminsList)
            {
                if(admin.GetUserName() == userName && admin.GetPassword() == password)
                {
                    return admin;
                }
                
            }
            foreach (var voter in VotersList)
            if (voter.GetUserName() == userName && voter.GetPassword() == password)
            {
                return voter;
            }

            return null;
        }

        // get all cnaditdate list
        public List<Candidate> GetCandidateList()
        {
            return new List<Candidate>(CandidatesList);
        }

        public Candidate? GetCandidateById(Guid id)
        {
            foreach (var candidate in CandidatesList)
            {
                if(candidate.GetCandidateID() == id)
                {
                    Console.WriteLine("Found Candidates by Id");
                    return candidate;
                }
            }
            Console.WriteLine("Could not find the Candidate.");
            return null;
        }
    }
}
