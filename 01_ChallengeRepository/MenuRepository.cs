using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ChallengeRepository
{
    public class MenuRepository
    {
        List<Menu> _menuList = new List<Menu>();

        public void AddToList(Menu meal)
        {
            _menuList.Add(meal);
        }

        public List<Menu> GetMenuList()
        {
            return _menuList;
        }

        public void RemoveFromList(int mealNumber)
        {
            foreach (Menu meal in _menuList)
            {
                if (meal.MealNumber == mealNumber)
                {
                    _menuList.Remove(meal);
                    break;
                }
            }
        }

        public void RemoveFromList(string mealName)
        {
            foreach (Menu meal in _menuList)
            {
                if (meal.MealName == mealName)
                {
                    _menuList.Remove(meal);
                    break;
                }
            }
        }

        public void SeedList()
        {
            Menu meal = new Menu(1, "BLT combo", "BLT with chips and a drink", LocalIngredient.Vegetables, 8.99m);
            Menu mealTwo = new Menu(2, "Cheeseburger combo", "Cheeseburger with fries and a drink", LocalIngredient.Beef, 10.99m);
            Menu mealThree = new Menu(3, "Fruit salad combo", "Fruit salad with a drink", LocalIngredient.Fruit, 8.49m);

            AddToList(meal);
            AddToList(mealTwo);
            AddToList(mealThree);
        }
    }
}