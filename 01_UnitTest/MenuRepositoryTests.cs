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
            Menu content = new Menu();

            content.MealNumber = 4;
            int expected = 4;
            Assert.AreEqual(expected, content.MealNumber);

            Menu contentTwo = new Menu(6, "Cheeseburger combo", "Cheeseburger, fries and drink", IngredientType.Add_Bacon, 8.99m);

            contentTwo.Price = 8.99m;
            decimal expectedTwoPrice = 8.99m;
            Assert.AreEqual(expectedTwoPrice, contentTwo.Price);
        }

        [TestMethod]
        public void AddToListTest()
        {
            MenuRepository menuRepo = new MenuRepository();
            List<Menu> contents = menuRepo.GetMenuList();

            Menu contentThree = new Menu(90, "Fish and chips", "battered fish with fries", IngredientType.Extra_Side, 9.99m);
            Menu contentFour = new Menu(72, "Soup and salad", "cup of soup and house salad", IngredientType.Extra_Side, 6.99m);

            menuRepo.AddMenuItem(contentThree);
            menuRepo.AddMenuItem(contentFour);

            int actual = contents.Count;
            int expectedThree = 2;
            Assert.AreEqual(expectedThree, actual);
        }

        [TestMethod]
        public void 
    }
}
