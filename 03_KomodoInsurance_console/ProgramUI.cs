using _03_KomodoInsurance_repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoInsurance_console
{
    class ProgramUI
    {
        private BadgeRepo _badgeRepo = new BadgeRepo();

        public void Run()
        {
            Menu();
        }

        // Menu
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display Options
                Console.WriteLine("Hello Security Admin\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit\n");

                // Get user input
                string input = Console.ReadLine();

                // Evaluate input
                switch (input)
                {
                    case "1":
                        // Add a badge
                        AddBadge();
                        break;
                    case "2":
                        // Edit a badge
                        UpdateBadge();
                        break;
                    case "3":
                        // List all badges
                        ListAllBadges();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number 1-4");
                        break;
                }


            }

        }

        private void AddBadge()
        {
            Console.Clear();
            // Create new Badge
            Badge badge = new Badge();

            // Get user input Badge Number
            badge.BadgeID = int.Parse(Console.ReadLine());

            // Get list of doors
            List<string> doors = new List<string>();
            bool keepRunning = true;
            while (keepRunning)
            {
                string input = Console.ReadLine();
                doors.Add(input);
                Console.WriteLine("Any other doors(y/n)?");
                input = Console.ReadLine();
                if(input.ToLower() == "n")
                {
                    keepRunning = false;
                }
                else if(input.ToLower() == "y")
                {
                    keepRunning = true;
                }
            }

            _badgeRepo.AddBadge(badge.BadgeID, badge);
        }

        private void UpdateBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number to update?");
            // Get user input
            int input = int.Parse(Console.ReadLine());
            // Get badge
            Badge badge = _badgeRepo.GetBadgeByKey(input);
            // Display badge doors
            string doorsString = StringOfDoors(badge.DoorNames);
            Console.WriteLine(doorsString);
        }

        private void ListAllBadges()
        {
            Console.Clear();
            var sb = new System.Text.StringBuilder();
            sb.Append(String.Format("{0,6},{1,15}\n", "Badge #"))
        }

        private string StringOfDoors(List<string> doors)
        {
            string doorsString = "";
            if(doors.Count == 1)
            {
                return doors[0];
            }
            foreach(var door in doors)
            {
                doorsString = doorsString + $" { door }";
            }
            return doorsString;
        }
    }
}
