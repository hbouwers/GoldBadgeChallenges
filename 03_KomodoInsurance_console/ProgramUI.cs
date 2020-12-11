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
                        break;
                    case "2":
                        // Edit a badge
                        break;
                    case "3":
                        // List all badges
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
    }
}
