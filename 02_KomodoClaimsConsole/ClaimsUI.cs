using _00_ValidationMethods;
using _02_KomodoClaimsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaimsConsole
{
    class ClaimsUI
    {
        private ClaimRepo _claimQueue = new ClaimRepo();

        public void Run()
        {
            SeedData();
            while (Menu())
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine("Goodbye!\n" +
                "Press any key to exit...");
            Console.ReadKey();
        }
        private void SeedData()
        {
            var seedClaim1 = new Claim(TypeOfClaim.Car, "Car accident on 465.", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            var seedClaim2 = new Claim(TypeOfClaim.Home, "House fire in kitchen.", 4000.00, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            var seedClaim3 = new Claim(TypeOfClaim.Theft, "Stolen pancakes.", 4.00, new DateTime(2018, 4, 27), new DateTime(2018, 4, 27));
            _claimQueue.AddClaimToQueue(seedClaim1);
            _claimQueue.AddClaimToQueue(seedClaim2);
            _claimQueue.AddClaimToQueue(seedClaim3);
        }
        private bool Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Komodo Insurance Claim Management Menu.\n\n");
            Console.WriteLine("Choose a menu item:\n\n" +
                "1. See all claims\n\n" +
                "2. Take care of next claim\n\n" +
                "3. Enter a new claim\n\n" +
                "0. Exit\n");

            switch (Console.ReadLine())
            {
                case "1":
                    DisplayAllClaims();
                    break;
                case "2":
                    DealWithNextClaim();
                    break;
                case "3":
                    CreateNewClaim();
                    break;
                case "0":
                    return false;
                default:
                    Console.WriteLine("Please enter a valid option");
                    break;
            }
            return true;
        }

        private void DisplayAllClaims()
        {
            Console.Clear();
            var allClaims = _claimQueue.GetAllClaims();
            Console.WriteLine("\nClaim ID  Type\t  Description\t\t\tAmount\t     DateOfIncident\tDateOfClaim\t  IsValid");
            foreach (var claim in allClaims)
            {
                DisplayClaim(claim);
            }
            Console.WriteLine();
        }

        private void DisplayClaim(Claim claim)
        {
            Console.WriteLine($"{claim.ClaimID,-10}{claim.ClaimType, -8}{claim.Description, -30}${claim.ClaimAmount, -12}{claim.DateOfIncident.ToShortDateString(), -19}{claim.DateOfClaim.ToShortDateString(), -18}{claim.IsValid}");
        }

        private void DealWithNextClaim()
        {
            Console.Clear();
            var claim = _claimQueue.GetNextClaim();
            Console.WriteLine($"Here are the details for the next claim to be handled:\n\n" +
                $"ClaimID:\t{claim.ClaimID}\n\n" +
                $"Type:\t{claim.ClaimType}\n\n" +
                $"Description:\t{claim.Description}\n\n" +
                $"Amount:\t${claim.ClaimAmount}\n\n" +
                $"DateOfIncident:\t{claim.DateOfIncident.ToShortDateString()}\n\n" +
                $"DateOfClaim:\t{claim.DateOfClaim.ToShortDateString()}\n\n" +
                $"IsValid:\t{claim.IsValid}\n\n\n" +
                $"Do you want to deal with this claim now (y/n)?");

            RemoveNextClaim();
        }

        public void RemoveNextClaim()
        {
            switch (Console.ReadLine().ToLower())
            {
                case "y":
                case "yes":
                    _claimQueue.RemoveClaimFromQueue();
                    Console.WriteLine("You have chosen to deal with the claim now.");
                    break;
                case "n":
                case "no":
                    Console.WriteLine("You have chosen not to deal the the claim now.");
                    break;
                default:
                    Console.WriteLine("That was an invalid entry.");
                    break;
            }
        }

        private void CreateNewClaim()
        {
            Console.Clear();

            //Type of claim
            Console.WriteLine("Enter the number for the type of claim:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n" +
                "4. Other\n");

            int typeAsInt = -1;
            bool keepRunning = true;

            while (keepRunning)
            {
                string intAsString = Validation.IntFromStringValidation();
                typeAsInt = int.Parse(intAsString);

                if (typeAsInt <= 4 && typeAsInt >= 1)
                {
                    keepRunning = false;
                }
                else
                {
                    Console.WriteLine("Please enter the number for one of the given options.");
                }
            }
            TypeOfClaim type = (TypeOfClaim)typeAsInt;

            Console.WriteLine("\nEnter a claim description:");
            string description = Console.ReadLine();

            Console.WriteLine("\nEnter the amount of the claim in dollars: $");
            string doubleAsString = Validation.DoubleFromStringValidation();
            double claimAmount = double.Parse(doubleAsString);

            Console.WriteLine("\nEnter the date of the incident (mm/dd/yyyy):");
            string incidentDateAsString = Validation.DateFromStringValidation();
            DateTime incidentDate = DateTime.Parse(incidentDateAsString);

            Console.WriteLine("\nEnter the date of the claim (mm/dd/yyyy)");
            string claimDateAsString = Validation.DateFromStringValidation();
            DateTime claimDate = DateTime.Parse(claimDateAsString);

            Claim newClaim = new Claim(type, description, claimAmount, incidentDate, claimDate);
            _claimQueue.AddClaimToQueue(newClaim);
        }
    }
}
