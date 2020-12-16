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
            SeedData();
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

                Console.WriteLine("Please press any key to continue...");
                Console.ReadLine();
                Console.Clear();
            }

        }

        private void AddBadge()
        {
            Console.Clear();
            // Create new Badge
            Badge badge = new Badge();

            // Get user input Badge Number
            Console.WriteLine("What is the number on the badge:");
            bool keepRunning = true;
            while (keepRunning)
            {
                try
                {
                    badge.BadgeID = int.Parse(Console.ReadLine());
                    keepRunning = false;
                }
                catch
                {
                    Console.WriteLine("Please enter numbers only");
                }
            }

            // Get list of doors
            List<string> doors = new List<string>();
            keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("List a door that it needs access to:");
                string input = Console.ReadLine();
                doors.Add(input);
                Console.WriteLine("Any other doors(y/n)?");
                bool keepRunning2 = true;
                while (keepRunning2)
                {
                    input = Console.ReadLine();

                    if (input.ToLower() == "n")
                    {
                        keepRunning = false;
                        keepRunning2 = false;
                    }
                    else if (input.ToLower() == "y")
                    {
                        keepRunning = true;
                        keepRunning2 = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter valid y or n");
                    }
                }
                
            }
            badge.DoorNames = doors;

            _badgeRepo.AddBadge(badge.BadgeID, badge);
        }

        private void UpdateBadge()
        {
            Console.Clear();
            ListAllBadges();
            Console.WriteLine("What is the badge number to update?");
            // Get user input
            int input = int.Parse(Console.ReadLine());
            // Get badge
            Badge badge = _badgeRepo.GetBadgeByKey(input);
            // Display badge doors
            string doorsString = StringOfDoors(badge.DoorNames);
            Console.WriteLine(input + " has access to doors " + doorsString);

            // door menu
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("What would you like to do?\n" + String.Format("{0,6}\n{1,6}","\t1.Remove a door","\t2.Add a door"));
                // get user input
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        // remove door
                        Console.WriteLine("Which door would you like to remove?");
                        string i = Console.ReadLine();
                        bool success = _badgeRepo.RemoveDoor(badge.BadgeID, i);
                        if (success)
                        {
                            Console.WriteLine("Door removed");
                        }
                        else
                        {
                            Console.WriteLine("There was a problem removing the door");
                        }
                        break;
                    case "2":
                        // add door
                        Console.WriteLine("List a door you want to add");
                        i = Console.ReadLine();
                        badge.DoorNames.Add(i);
                        break;
                    case "3":
                        // exit
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid value 1-3");
                        break;
                }
            }
        }

        private void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, Badge> badgeDictionary = _badgeRepo.GetBadges();
            var sb = new System.Text.StringBuilder();
            sb.Append(String.Format("{0,-8} {1,-15}\n", "Badge #", "Door Access"));
            foreach(var kvp in badgeDictionary)
            {
                string doorsString = StringOfDoors(kvp.Value.DoorNames);
                sb.Append(String.Format("{0,-8} {1,-15}\n", kvp.Key, doorsString));
            }
            Console.WriteLine(sb);
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
                if (doors.Last() == door)
                {
                    doorsString = doorsString + $"{door}";
                }
                else
                {
                    doorsString = doorsString + $"{ door },";
                }
            }
            return doorsString;
        }

        private void SeedData()
        {
            Badge first = new Badge(12345, new List<string> { "A7" });
            Badge second = new Badge(22345, new List<string> { "A1","A4","B1","B2" });
            Badge third = new Badge(32345, new List<string> { "A4","A5" });

            _badgeRepo.AddBadge(first.BadgeID,first);
            _badgeRepo.AddBadge(second.BadgeID,second);
            _badgeRepo.AddBadge(third.BadgeID,third);
        }
    }
}
