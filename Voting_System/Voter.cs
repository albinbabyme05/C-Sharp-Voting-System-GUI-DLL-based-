using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting_System
{
    public class Voter : User
    {
        private bool hasVoted;
        private Guid VoterId;
        public Voter(string voterName, string userPassword) : base(voterName, userPassword)
        {
            VoterId = Guid.NewGuid();
            hasVoted = false;
        }

        public Guid GetVoterId() => VoterId;
        public bool GetHasVoted() => hasVoted;
        

        public bool Vote(string candidateId)
        {
            if (hasVoted)
            {
                Console.WriteLine("You already voted");
                return false;
            }
            Console.WriteLine($"voted successfully to {candidateId}");
            hasVoted = true;
            return true;
        }

        public override void AccessPortal()
        {
            Console.WriteLine($"Welcome, Voter {VoterId}! Accessing voting screen...");
        }
    }
}
