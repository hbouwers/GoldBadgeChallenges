using _02_Claims_repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _02_Claims_console
{
    class ProgramUI
    {
        private ClaimRepo _claimRepo = new ClaimRepo();

        public void Run() 
        {
            SeedData();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display options
                Console.WriteLine("Choose a menu item:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit\n");

                // Get user input
                string input = Console.ReadLine();

                // Evaluate user's input
                switch (input)
                {
                    case "1":
                        // See all Claims
                        DisplayAllClaims();
                        break;
                    case "2":
                        // Next Claim
                        DisplayNextClaim();
                        break;
                    case "3":
                        // Enter new claim
                        CreateNewClaim();
                        break;
                    case "4":
                        // Exit
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        // See all claims
        private void DisplayAllClaims()
        {
            Console.Clear();
            // Get claims
            Queue<Claim> claims = _claimRepo.GetClaims();

            // Display claims
            //Console.WriteLine("ClaimID\t" + "Type\t" + "Description\t\t" + "Amount\t" + "DateOfAccident\t" + "DateOfClaim\t" + "IsValid");
            Console.WriteLine(String.Format("{0,-8} {1,-6} {2,-25} {3,-8} {4,-15} {5,-15} {6,-8}\n", "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid"));

            foreach (Claim i in claims)
            {
                Console.WriteLine(String.Format("{0,-8} {1,-6} {2,-25} {3,-8} {4,-15} {5,-15} {6,-8}", i.ClaimId,i.ClaimType,i.Description,i.ClaimAmount,i.DateofIncident.ToShortDateString(),i.DateOfClaim.ToShortDateString(), i.IsValid));
                // Console.WriteLine($"{i.ClaimId}\t" + $"{i.ClaimType}\t" + $"{i.Description}\t" + $"{i.ClaimAmount}\t" + $"{i.DateofIncident.ToShortDateString()}\t" + $"{i.DateOfClaim.ToShortDateString()}\t" + $"{i.IsValid}");
            }
        }


        // Take care of the next claim
        private void DisplayNextClaim()
        {
            Console.Clear();
            // Get next item in list
            Claim claim = _claimRepo._claims.First();

            // Display claim
            Console.WriteLine($"ClaimId: {claim.ClaimId}\n" + $"Type: {claim.ClaimType}\n" + $"Description: {claim.Description}\n" + $"DateOfAccident: {claim.DateofIncident}\n" + $"DateOfClaim: {claim.DateOfClaim}\n" + $"IsValid: {claim.IsValid}\n");

            // Query the user
            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            bool keepRunning = true;
            while (keepRunning)
            {
                string input = Console.ReadLine();
                if(input == "y")
                {
                    _claimRepo.RemoveClaimFromTopOfQueue();
                    keepRunning = false;
                }
                else if(input == "n")
                {
                    _claimRepo.RemoveClaimFromTopOfQueue();
                    _claimRepo.AddClaim(claim);
                    keepRunning = false;
                }
                else
                {
                    Console.WriteLine("Please enter y or n");
                }
            }
        }

        // Enter a new claim
        private void CreateNewClaim()
        {
            Console.Clear();

            // Create new claim
            Claim claim = new Claim();

            // Get claim type
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Enter the claim type(1-3):\n" +
                    "1. Car\n" +
                    "2. Home\n" + 
                    "3. Theft"
                    );
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        // car
                        claim.ClaimType = TypeOfClaim.Car;
                        keepRunning = false;
                        break;
                    case "2":
                        // home
                        claim.ClaimType = TypeOfClaim.Home;
                        keepRunning = false;
                        break;
                    case "3":
                        // theft
                        claim.ClaimType = TypeOfClaim.Theft;
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter valid number 1-3");
                        break;
                }
            }

            // Get description
            Console.WriteLine("Enter a claim description:");
            claim.Description = Console.ReadLine();

            // Get amount of damage
            Console.WriteLine("Amount of Damage:");
            keepRunning = true;
            while(keepRunning)
            try
            {
                claim.ClaimAmount = int.Parse(Console.ReadLine());
                keepRunning = false;
            }
            catch
            {
                Console.WriteLine("Please enter numbers only");
            }

            // Get date of accident
            Console.WriteLine("Date of Accident:");
            keepRunning = true;
            while (keepRunning)
            {
                try 
                {
                    claim.DateofIncident = DateTime.Parse(Console.ReadLine());
                    keepRunning = false;
                }
                catch
                {
                    Console.WriteLine("Please enter a valid date - eg ##/##/####");
                }
            }
            

            // Get date of claim
            Console.WriteLine("Date of Claim:");
            keepRunning = true;
            while (keepRunning)
            {
                try
                {
                    claim.DateOfClaim = DateTime.Parse(Console.ReadLine());
                    keepRunning = false;
                }
                catch
                {
                    Console.WriteLine("Please enter a valid date - eg ##/##/####");
                }
            }
            

            // isValid
            if (claim.IsValid)
            {
                Console.WriteLine("This claim is valid.");
            }
            else
            {
                Console.WriteLine("This claim is not valid.");
            }

            _claimRepo.AddClaim(claim);
        }

        // Seed data
        private void SeedData()
        {
            Claim car = new Claim(TypeOfClaim.Car, "Car Accident on 465.",400,new DateTime(2018,4,25),new DateTime(2018,4,27));
            Claim home = new Claim(TypeOfClaim.Home, "House fire in kitchen.", 4000,new DateTime(2018,4,11),new DateTime(2018,4,12));
            Claim theft = new Claim(TypeOfClaim.Theft, "Stolen pancakes.",4,new DateTime(2018,4,27),new DateTime(2018,6,1));

            _claimRepo.AddClaim(car);
            _claimRepo.AddClaim(home);
            _claimRepo.AddClaim(theft);
        }
    }
}
