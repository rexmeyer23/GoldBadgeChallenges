using KomodoClaimsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    class ProgramUI
    {
        private readonly ClaimRepo _claimRepo = new ClaimRepo();
        public void Run()
        {
            ClaimQueue();
            RunMenu();
        }
        public void RunMenu()
        {
            bool runApplication = true;
            while (runApplication)
            {
                Console.Clear();
                Console.WriteLine("Please enter the number to select the following option\n" +
                    "1. See All Claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter a New Claim\n" +
                    "4. Exit\n");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        ShowAllClaims();
                        break;
                    case 2:
                        GetClaimFromQueue();
                        break;
                    case 3:
                        CreateNewClaim();
                        break;

                    case 4:
                        Console.WriteLine("Goodbye!");
                        Console.ReadKey();
                        runApplication = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
            }
        }
        //option 1: view claims
        public void ShowAllClaims()
        {
            Queue<Claim> listClaims = _claimRepo.ListClaims();
            string[] textNames = { "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid" };
            
            foreach (Claim claim in listClaims)
            {
                Console.WriteLine($"{textNames[0],-10}{textNames[1],-10}{textNames[2],-10}{textNames[3],8}{textNames[4],15}{textNames[5],15}{textNames[6],15}");
                Console.WriteLine($"{claim.ClaimID,-10}{claim.TypeOfClaim,-10}{claim.Description,-10}${claim.ClaimAmount,8}{claim.DateOfIncident,15: MM/dd/yyyy}{claim.DateOfClaim,15: MM/dd/yyyy}{claim.IsValid,15}");
                Console.WriteLine("==================");
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        public void DisplayClaims(Claim claim)
        {
            Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
               $"Type: {claim.ClaimID}\n" +
               $"Description: {claim.Description}\n" +
               $"Amount: ${claim.ClaimAmount}\n" +
               $"DateOfAccident: {claim.DateOfIncident: MM/dd/yyyy}\n" +
               $"DateOfClaim: {claim.DateOfClaim: MM/dd/yyyy}\n" +
               $"IsValid: {claim.IsValid}\n");
        }
        
        public void ClaimQueue()
        {
            _claimRepo.FileNewClaim(new Claim(1, ClaimType.Car, "Vehicle totaled on I-69.", 6000.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 30)));
            _claimRepo.FileNewClaim(new Claim(2, ClaimType.Home, "House struck by lightening.", 80234.00m, new DateTime(2018, 1, 15), new DateTime(2018, 1, 16)));
            _claimRepo.FileNewClaim(new Claim(3, ClaimType.Theft, "Stolen laptop.", 3123.42m, new DateTime(2018, 4, 29), new DateTime(2018, 5, 30)));
        }
        //option 2: take care of next claim
        private void GetClaimFromQueue()
        {
            Console.Clear();
            Claim claim = _claimRepo.PeekFirstClaim();
            DisplayClaims(claim);
            Console.WriteLine("Do you want to deal with this claim now?\n" +
                "YES or NO\n");
            string input = Console.ReadLine().ToUpper();
            switch (input)
            {
                case "YES":
                    _claimRepo.RemoveClaim();
                    ShowAllClaims();
                    Console.WriteLine("Claim has been removed from queue.\n" +
                        "You are now dealing with this claim.");
                    Console.ReadKey();
                    break;
                case "NO":
                    Console.WriteLine("Claim remains in menu.");
                    break;
                default:
                    Console.WriteLine("Please enter YES or NO.");
                    break;
            }
        }
        //option 3: enter a new claim
        private void CreateNewClaim()
        {
            Claim newClaim = new Claim();
            Console.Write("Please enter the ID of the new claim: ");
            newClaim.ClaimID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please select a claim type by entering one of the following numbers below:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            int claimType = Convert.ToInt32(Console.ReadLine());
            switch (claimType)
            {
                case 1:
                    newClaim.TypeOfClaim = ClaimType.Car;
                    break;
                case 2:
                    newClaim.TypeOfClaim = ClaimType.Home;
                    break;
                case 3:
                    newClaim.TypeOfClaim = ClaimType.Theft;
                    break;
                default:
                    Console.Write("Please enter a valid number: \n");
                    break;

            }
            Console.WriteLine("Please enter a brief description of claim.");
            newClaim.Description = Console.ReadLine();
            Console.Write("Please enter a claim amount: ");
            newClaim.ClaimAmount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Please enter the date of the accident in the following format below.\n" +
                "MM/DD/YYYY\n");
            DateTime dateOfAccident = DateTime.Parse(Console.ReadLine());
            newClaim.DateOfIncident = dateOfAccident;
            newClaim.DateOfClaim = DateTime.Now;
            if (newClaim.IsValid) 
            {
                Console.WriteLine("Claim is valid.");
            }
            else
            {
                Console.WriteLine("Claim not valid.");
            }
            _claimRepo.FileNewClaim(newClaim);
            Console.WriteLine("Claim has been added to queue");
            Console.ReadKey();
            Console.Clear();
            ShowAllClaims();
            Console.WriteLine("Press any key to exit...");

        }
    }
}
