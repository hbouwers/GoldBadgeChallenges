using System;
using System.Collections.Generic;
using _01_KomodCafe_repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_KomodoCafe_tests
{
    [TestClass]
    public class KomodoCafeRepoTests
    {
        // These are fields yo. Use them in all the test methods you want. That's it. You know you want to
        private MenuRepository _repo;
        private Menu _menuItem;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepository();
            string[] pizzaArray = { "dough", "marinara sauce", "cheese", "pepperoni" };
            List<string> pizzaIngredients = new List<string>(pizzaArray);
            _menuItem = new Menu("Pepperoni Pizza", "Classic New York style pizza", pizzaIngredients, 15);

            _repo.AddMenuItem(_menuItem);
        }

        [TestMethod]
        public void AddItemShouldReturnTrue()
        {
            // Arrange
            string[] spaghettiArray = { "noodles", "marinara sauce" };
            List<string> spaghettiIngredients = new List<string>(spaghettiArray);
            Menu spaghetti = new Menu("Spaghetti", "Noodles with a delicious marinara sauce", spaghettiIngredients, 10);

            // Act
            bool success = _repo.AddMenuItem(spaghetti);

            // Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void GetMenuItemShouldBeTypeItem()
        {
            // Arrange 

            // Act
            Menu expected = _menuItem;
            Menu actual = _repo.GetMenuItemById(1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMenuShouldReturnList()
        {
            // Arrange

            // Act
            List<Menu> expected = _repo._menu;
            List<Menu> actual = _repo.GetMenu();

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void DeleteItemShouldReturnTrue()
        {
            // Arrange

            // Act
            bool success = _repo.DeleteMenuItem(1);

            // Assert
            Assert.IsTrue(success);
        }
    }
}
