using _01_KomodCafe_repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge
{
    class ProgramUI
    {
        private MenuRepository _menuRepository = new MenuRepository();

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
                // Display options to user
                Console.WriteLine("Select a menu option \n" +
                    "1. Add A Menu\n" +
                    "2. View Menu\n" +
                    "3. View Menu Item\n" +
                    "4. Delete Menu Item\n" +
                    "5. Exit \n"
                    );

                // Get the user's input
                string input = Console.ReadLine();

                // Evaluate the user's input
                switch (input)
                {
                    case "1":
                        // Create new menu item
                        CreateNewMenuItem();
                        break;
                    case "2":
                        // View menu
                        ViewMenu();
                        break;
                    case "3":
                        // View menu item
                        ViewMenuItem();
                        break;
                    case "4":
                        // Delete menu item
                        DeleteMenuItem();
                        break;
                    case "5":
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

        // Create new menu item
        private void CreateNewMenuItem()
        {
            Console.Clear();
            Menu item = new Menu();
            List<string> ingredients = new List<string>();

            // Meal Name
            Console.WriteLine("Enter the meal name");
            item.MealName = Console.ReadLine();

            // Description
            Console.WriteLine("Enter the description");
            item.Description = Console.ReadLine();

            // Ingredients
            bool run = true;
            while (run)
            {
                Console.WriteLine("Enter an ingredient or press enter to continue");
                string ingredient = Console.ReadLine();
                if (ingredient == "")
                {
                    run = false;
                }
                else
                {
                    ingredients.Add(ingredient);
                }
            }

            item.Ingredients = ingredients;

            // Price
            run = true;
            while (run)
            {
                try
                {
                    Console.WriteLine("Enter the price");
                    int price = int.Parse(Console.ReadLine());
                    item.Price = price;
                    if (_menuRepository.AddMenuItem(item))
                    {
                        Console.WriteLine("Item successfully added!");
                    }
                    else
                    {
                        Console.WriteLine("There was a problem adding the item");
                    }
                    run = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
        }
        // View menu
        private void ViewMenu()
        {
            Console.Clear();

            // Get menu items
            List<Menu> menu = _menuRepository.GetMenu();

            // Display Id and Meal name
            foreach (Menu i in menu)
            {
                Console.WriteLine("Id: " + i.Id + " " + i.MealName);
            }
        }

        // View menu item
        private void ViewMenuItem()
        {
            // Display menu items
            ViewMenu();

            // Get user input
            Console.WriteLine("Enter the id of the meal you would like to see");
            try
            {
                int input = int.Parse(Console.ReadLine());

                // Get Item
                Menu item = _menuRepository.GetMenuItemById(input);

                // Null check
                if (item == null)
                {
                    Console.WriteLine("No item by that id");
                }

                // Display item
                Console.WriteLine(
                    $"Name: {item.MealName}\n" +
                    $"Description: {item.Description}\n" +
                    $"Ingredients: " + StringOfIngredients(item.Ingredients) + "\n" +
                    $"Price: ${item.Price}\n"
                    );
            }
            catch
            {
                Console.WriteLine("Invalid input");
            }
        }


        // Delete menu item
        private void DeleteMenuItem()
        {
            ViewMenu();

            // Get user input
            Console.WriteLine("Enter the id of the item you would like to delete");
            try
            {
                int input = int.Parse(Console.ReadLine());

                // Get item
                if (_menuRepository.DeleteMenuItem(input))
                {
                    Console.WriteLine("Item successfully deleted");
                }
                else
                {
                    Console.WriteLine("There was a problem deleting the item");
                }
            }
            catch
            {

                Console.WriteLine("invalid input");
            }

        }

        // Ingredients to string helper
        private string StringOfIngredients(List<string> ingredients)
        {
            string ingredientsString = "";
            foreach (string ingredient in ingredients)
            {
                if(ingredients[0] == ingredient)
                {
                    ingredientsString = ingredient;
                }
                ingredientsString = ingredientsString +", "+ ingredient;
            }
            return ingredientsString;
        }

        // Seed data
        private void SeedData()
        {
            string[] spaghettiArray = { "noodles", "marinara sauce" };
            List<string> spaghettiIngredients = new List<string>(spaghettiArray);
            Menu spaghetti = new Menu("Spaghetti", "Noodles with a delicious marinara sauce", spaghettiIngredients, 10);

            string[] pizzaArray = { "dough", "marinara sauce", "cheese", "pepperoni" };
            List<string> pizzaIngredients = new List<string>(pizzaArray);
            Menu pizza = new Menu("Pepperoni Pizza", "Classic New York style pizza", pizzaIngredients, 15);

            string[] alfredoArray = { "alfredo sauce", "noodles", "chicken" };
            List<string> alfredoIngredients = new List<string>(alfredoArray);
            Menu alfredo = new Menu("Chicken Alfredo", "Delicious alfredo sauce from walmart over a nice over cooked pasta and grilled chicken", alfredoIngredients, 12);

            _menuRepository.AddMenuItem(spaghetti);
            _menuRepository.AddMenuItem(pizza);
            _menuRepository.AddMenuItem(alfredo);
        }
    }
}
