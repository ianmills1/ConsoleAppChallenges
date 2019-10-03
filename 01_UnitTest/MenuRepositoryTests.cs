using System;
using System.Collections.Generic;
using _01_ChallengeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_UnitTest
{
    [TestClass]
    public class MenuRepositoryTests
    {

        [TestMethod]
        public void CreateMenuItemTest()
        {
            Menu meal = new Menu();

            meal.MealNumber = 2;
            int expected = 2;
            Assert.AreEqual(expected, meal.MealNumber);

            Menu mealTwo = new Menu(2, "Cheeseburger combo", "Cheeseburger with fries and a drink", LocalIngredient.Beef, 10.99m);

            mealTwo.Price = 10.99m;
            decimal expectedTwoPrice = 10.99m;
            Assert.AreEqual(expectedTwoPrice, mealTwo.Price);
        }

        [TestMethod]
        public void AddToListTest()
        {
            MenuRepository menuRepo = new MenuRepository();
            List<Menu> meal = menuRepo.GetMenuList();

            Menu mealThree = new Menu(1, "BLT combo", "BLT with chips and a drink", LocalIngredient.Vegetables, 8.99m);
            Menu mealFour = new Menu(3, "Fruit salad", "Fruit salad and a drink", LocalIngredient.Fruit, 8.49m);

            menuRepo.AddToList(mealThree);
            menuRepo.AddToList(mealFour);

            int actual = meal.Count;
            int expectedThree = 2;
            Assert.AreEqual(expectedThree, actual);
        }

        [TestMethod]
        public void RemoveFromListByMealNumberTest()
        {
            MenuRepository menuRepo = new MenuRepository();
            List<Menu> meal = menuRepo.GetMenuList();

            Menu mealTwo = new Menu(2, "Cheeseburger combo", "Cheeseburger with fries and a drink", LocalIngredient.Beef, 10.99m);
            Menu mealThree = new Menu(1, "BLT combo", "BLT with chips and a drink", LocalIngredient.Vegetables, 8.99m);
            Menu mealFour = new Menu(3, "Fruit salad", "Fruit salad and a drink", LocalIngredient.Fruit, 8.49m);

            menuRepo.AddToList(mealTwo);
            menuRepo.AddToList(mealThree);
            menuRepo.AddToList(mealFour);

            menuRepo.RemoveFromList(3);

            int expected = 2;
            int actual = meal.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveFromListByMealName()
        {
            MenuRepository menuRepo = new MenuRepository();
            List<Menu> meal = menuRepo.GetMenuList();

            Menu mealTwo = new Menu(2, "Cheeseburger combo", "Cheeseburger with fries and a drink", LocalIngredient.Beef, 10.99m);
            Menu mealThree = new Menu(1, "BLT combo", "BLT with chips and a drink", LocalIngredient.Vegetables, 8.99m);
            Menu mealFour = new Menu(3, "Fruit salad", "Fruit salad and a drink", LocalIngredient.Fruit, 8.49m);

            menuRepo.AddToList(mealTwo);
            menuRepo.AddToList(mealThree);
            menuRepo.AddToList(mealFour);

            menuRepo.RemoveFromList("Cheeseburger combo");

            int expected = 2;
            int actual = meal.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}