using _02_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge_Console
{
    internal class ProgramUI
    {
        ClaimRepository _claimRepo = new ClaimRepository();

        public ProgramUI()
        {

        }

        public void Run()
        {
            _claimRepo.SeedList();
            RunMenu();
        }

        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("Enter the number of the menu item you would like to see: \n" +
                    "1. See All Claims\n" +
                    "2. Service Next Claim\n" +
                    "3. Enter New Claim\n" +
                    "4. Exit\n");

                string userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        ServiceNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                }
            }
        }

        public void SeeAllClaims()
        {
            Queue<Claim> claimQueue = _claimRepo.GetClaimQueue();

            Console.WriteLine("Claim ID \t Claim type \t Description \t\t Claim amount \t\t Date of incident \t\t Date of claim \t\t Valid claim?\n");

            foreach (Claim incident in claimQueue)
            {
                Console.WriteLine($"{incident.ClaimID} \t\t {incident.Category} \t\t {incident.Description} \t\t {incident.ClaimAmount} \t {incident.DateOfIncident} \t {incident.DateOfClaim} \t\t {incident.IsValid}\n");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public void EnterNewClaim()
        {
            Console.WriteLine("Enter claim ID: \n");
            string claimIDAsString = Console.ReadLine();
            int claimID = int.Parse(claimIDAsString);
            Console.Clear();

            Console.WriteLine("Enter number of claim type from list below: \n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            string categoryAsString = Console.ReadLine();
            ClaimCategory category = (ClaimCategory)int.Parse(categoryAsString);
            Console.Clear();

            Console.WriteLine("Enter a description of incident: \n");
            string description = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Enter claim amount: \n");
            string claimAmountAsString = Console.ReadLine();
            float claimAmount = float.Parse(claimAmountAsString);
            Console.Clear();

            Console.WriteLine("Enter date of incident (mm/dd/yyyy): \n");
            string dateOfIncidentAsString = Console.ReadLine();
            DateTime dateOfIncident = DateTime.Parse(dateOfIncidentAsString);
            Console.Clear();

            Console.WriteLine("Enter date of claim (mm/dd/yyyy): \n");
            string dateOfClaimAsString = Console.ReadLine();
            DateTime dateOfClaim = DateTime.Parse(dateOfClaimAsString);
            Console.Clear();

            Claim incident = new Claim(claimID, category, description, claimAmount, dateOfIncident, dateOfClaim);
            _claimRepo.AddToQueue(incident);
            Console.WriteLine("Press any key to continue...\n");
            Console.ReadKey();
            Console.Clear();
        }

        public void ServiceNextClaim()
        {
            Queue<Claim> incidentQueue = _claimRepo.GetClaimQueue();

            Claim incident = incidentQueue.Peek();
            Console.WriteLine($"Claim ID: {incident.ClaimID}, Claim type: {incident.Category}, Description: {incident.Description}, \n" +
                    $"Claim amount($): {incident.ClaimAmount}, Date of incident: {incident.DateOfIncident}, \n" +
                    $"Date of claim: {incident.DateOfClaim}, Valid claim: {incident.IsValid}\n");
            Console.WriteLine("Press any key to continue...\n");
            Console.ReadKey();

            Console.WriteLine("Would you like to deal with this claim now (y/n)?\n");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "y":
                    RemoveNextClaimFromQueue();
                    break;
                case "n":
                    break;
            }
            Console.Clear();
        }
        public void RemoveNextClaimFromQueue()
        {
            Queue<Claim> incidentQueue = _claimRepo.GetClaimQueue();
            Claim incident = incidentQueue.Dequeue();
            Console.WriteLine("You have successfully removed this claim from the queue. Press any key to continue...\n");
            Console.ReadKey();
        }
    }
}