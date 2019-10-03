using _01_ChallengeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge_Console
{
    internal class ProgramUI
    {
        MenuRepository _menuRepo = new MenuRepository();

        public ProgramUI()
        {

        }

        public void Run()
        {
            _menuRepo.SeedList();
            RunMenu();
        }

        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {

                Console.WriteLine("Enter the number of the menu item you would like to see: \n" +
                    "1. Create Menu Item\n" +
                    "2. Remove Menu Item\n" +
                    "3. See All Menu Items\n" +
                    "4. Exit\n");

                string userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case "1":
                        AddMenuItem();
                        break;
                    case "2":
                        RemoveMenuItem();
                        break;
                    case "3":
                        SeeAllMenuItems();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                }
            }
        }

        public void AddMenuItem()
        {
            Console.WriteLine("Meal number of the menu item you would like to add: \n");
            string mealNumberAsString = Console.ReadLine();
            int mealNumber = int.Parse(mealNumberAsString);
            Console.Clear();

            Console.WriteLine("Meal name of the menu item you would like to add: \n");
            string mealName = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Description of the menu item you would like to add: \n");
            string description = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Locally sourced ingredient used in this menu item: \n" +
                "1. Beef\n" +
                "2. Fish\n" +
                "3. Organic Vegetables\n" +
                "4. Organic Fruit\n" +
                "5. Eggs\n" +
                "6. Dairy\n");
            string ingredientAsString = Console.ReadLine();
            int ingredientAsInt = int.Parse(ingredientAsString);
            LocalIngredient ingredient = (LocalIngredient)ingredientAsInt;
            Console.Clear();

            Console.WriteLine("Price of the menu item you would like to add: \n");
            string priceAsString = Console.ReadLine();
            decimal price = decimal.Parse(priceAsString);
            Console.Clear();

            Menu meal = new Menu(mealNumber, mealName, description, ingredient, price);

            _menuRepo.AddToList(meal);
            Console.WriteLine("Press any key to continue...\n");
            Console.ReadKey();
            Console.Clear();
        }

        public void RemoveMenuItem()
        {
            SeeAllMenuItems();
      
            Console.WriteLine("Enter either the meal number or meal name you would like to remove: \n");

            string userInput = Console.ReadLine();

            int result;
            if(int.TryParse(userInput, out result))
            {
                _menuRepo.RemoveFromList(result);
            }
            else
            {
                _menuRepo.RemoveFromList(userInput);
            }
            Console.Clear();
        }

        public void SeeAllMenuItems()
        {
            List<Menu> menuList = _menuRepo.GetMenuList();

            foreach (Menu meal in menuList)
            {
                Console.WriteLine($"Meal number: {meal.MealNumber}, Meal name: {meal.MealName}, Description: {meal.Description}, Local ingredient: {meal.Ingredient}, Price: {meal.Price}\n");
            }
            Console.WriteLine("Press any key to continue...\n");
            Console.ReadKey();
            Console.Clear();

        }
    }
}