using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodCafe_repo
{
    public class Menu
    {
        public int Id { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public int Price { get; set; }
        public Menu() { }
        public Menu(string mealName, string description, List<string> ingredients, int price)
        {
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
