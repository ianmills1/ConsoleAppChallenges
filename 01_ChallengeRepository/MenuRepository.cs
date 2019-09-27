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

        public void AddMenuItem(Menu content)
        {
            _menuList.Add(content);
        }

        public List<Menu> GetMenuList()
        {
            return _menuList;
        }

        public void RemoveMenuItem(int mealNumber)
        {
            foreach (Menu content in _menuList)
            {
                if (content.MealNumber == mealNumber)
                {
                    _menuList.Remove(content);
                }
            }
        }

        public void RemoveMenuItem(string mealName)
        {
            foreach (Menu content in _menuList)
            {
                if (content.MealName == mealName)
                {
                    _menuList.Remove(content);
                }
            }
        }

        public void SeedList()
        {
            Menu content = new Menu(5, "BLT combo", "BLT with chips and drink", IngredientType.Extra_Meat, 8.99m);
            Menu contentTwo = new Menu(8, "Half sandwich and soup", "Half of one of our sandwiches and a cup of your favorite soup", IngredientType.Add_Bacon, 6.99m);
            Menu contentThree = new Menu(10, "Club sandwich combo", "Club sandwich with chips and drink", IngredientType.Extra_Side, 8.49m);

            AddMenuItem(content);
            AddMenuItem(contentTwo);
            AddMenuItem(contentThree);
        }
    }
}
