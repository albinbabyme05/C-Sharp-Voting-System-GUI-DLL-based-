namespace Voting_System;

public class Program
{
    static void Main(string[] args)
    {
        VotingSystem manager = new VotingSystem();

        // Creating Voters
        Voter v1 = new Voter("Albin", "alb123");
        Voter v2 = new Voter("Aline", "Ali123");
        Voter v3 = new Voter("Angel", "Ang123");
        Voter v4 = new Voter("Amal", "Ama123");
        Voter v5 = new Voter("Unni", "Unn123");

        // Creating Candidates
        Candidate c1 = new Candidate("K Sudakaran", "UDF");
        Candidate c2 = new Candidate("P Vijayan", "LDF");
        Candidate c3 = new Candidate("K Suredran", "BJP");

        // Creating Admin
        Admin admin1 = new Admin("admin1", "admin123");

        // Admin adds candidates
        admin1.AddCandidate(c1);
        admin1.AddCandidate(c2);
        admin1.AddCandidate(c3);

        // Also adding candidates manually to VotingSystem
        manager.GetCandidateList().Add(c1);
        manager.GetCandidateList().Add(c2);
        manager.GetCandidateList().Add(c3);

        // Registering Voters and Admins in VotingSystem
        manager.RegisterVoters(v1);
        manager.RegisterVoters(v2);
        manager.RegisterVoters(v3);
        manager.RegisterVoters(v4);
        manager.RegisterVoters(v5);

        manager.RegisterAdmin(admin1);

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Welcome to Online Voting System ---");
            Console.WriteLine("1. Admin Login");
            Console.WriteLine("2. Voter Login");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("\nEnter Admin Username: ");
                    string? adminUsername = Console.ReadLine();
                    Console.Write("Enter Admin Password: ");
                    string? adminPassword = Console.ReadLine();

                    User? adminUser = manager.AuthenticateUser(adminUsername!, adminPassword!);
                    if (adminUser is Admin admin)
                    {
                        bool adminMenu = true;
                        while (adminMenu)
                        {
                            Console.WriteLine("\n--- Admin Panel ---");
                            Console.WriteLine("1. Add Candidate");
                            Console.WriteLine("2. Remove Candidate");
                            Console.WriteLine("3. View Results");
                            Console.WriteLine("4. Logout");
                            Console.Write("Choose an option: ");
                            string? adminChoice = Console.ReadLine();

                            switch (adminChoice)
                            {
                                case "1":
                                    Console.Write("\nEnter Candidate Name: ");
                                    string? candidateName = Console.ReadLine();
                                    Console.Write("Enter Party Name: ");
                                    string? partyName = Console.ReadLine();
                                    Candidate newCandidate = new Candidate(candidateName!, partyName!);
                                    admin.AddCandidate(newCandidate);
                                    manager.GetCandidateList().Add(newCandidate); // <-- Important
                                    Console.WriteLine("Candidate Added Successfully!");
                                    break;
                                case "2":
                                    Console.Write("\nEnter Candidate ID to Remove: ");
                                    string? removeIdStr = Console.ReadLine();
                                    if (Guid.TryParse(removeIdStr, out Guid removeId))
                                    {
                                        admin.RemoveCandidate(removeId);
                                        Candidate? toRemove = manager.GetCandidateById(removeId);
                                        if (toRemove != null)
                                        {
                                            manager.GetCandidateList().Remove(toRemove);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Candidate ID Format.");
                                    }
                                    break;
                                case "3":
                                    Console.WriteLine("\n--- Voting Results ---");
                                    var results = admin.ViewResult(manager.GetCandidateList());
                                    foreach (var result in results)
                                    {
                                        Console.WriteLine($"{result.Key} - {result.Value} Votes");
                                    }
                                    break;
                                case "4":
                                    adminMenu = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid Option. Try again.");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Admin Credentials.");
                    }
                    break;

                case "2":
                    Console.Write("\nEnter Voter Username: ");
                    string? voterUsername = Console.ReadLine();
                    Console.Write("Enter Voter Password: ");
                    string? voterPassword = Console.ReadLine();

                    User? voterUser = manager.AuthenticateUser(voterUsername!, voterPassword!);
                    if (voterUser is Voter voter)
                    {
                        bool voterMenu = true;
                        while (voterMenu)
                        {
                            Console.WriteLine("\n--- Voter Panel ---");
                            Console.WriteLine("1. View Candidates");
                            Console.WriteLine("2. Vote");
                            Console.WriteLine("3. Check Voting Status");
                            Console.WriteLine("4. Logout");
                            Console.Write("Choose an option: ");
                            string? voterChoice = Console.ReadLine();

                            switch (voterChoice)
                            {
                                case "1":
                                    Console.WriteLine("\n--- Candidates List ---");
                                    var candidates = manager.GetCandidateList();
                                    foreach (var candidate in candidates)
                                    {
                                        Console.WriteLine($"{candidate.GetCandidateID()} - {candidate.Name} ({candidate.Party})");
                                    }
                                    break;
                                case "2":
                                    if (voter.GetHasVoted())
                                    {
                                        Console.WriteLine("You have already voted.");
                                    }
                                    else
                                    {
                                        Console.Write("\nEnter Candidate ID to Vote: ");
                                        string? candidateIdStr = Console.ReadLine();
                                        if (Guid.TryParse(candidateIdStr, out Guid candidateId))
                                        {
                                            Candidate? candidate = manager.GetCandidateById(candidateId);
                                            if (candidate != null)
                                            {
                                                candidate.SetVoteCount();
                                                voter.Vote(candidateId.ToString());
                                                Console.WriteLine("Vote cast successfully!");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Candidate not found.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid Candidate ID Format.");
                                        }
                                    }
                                    break;
                                case "3":
                                    bool hasVoted = voter.GetHasVoted();
                                    Console.WriteLine(hasVoted ? "You have voted." : "You have not voted yet.");
                                    break;
                                case "4":
                                    voterMenu = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid Option. Try again.");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Voter Credentials.");
                    }
                    break;

                case "3":
                    running = false;
                    Console.WriteLine("Exiting the Voting System. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid Option. Try again.");
                    break;
            }
        }
    }
}
