using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ChallengeRepository
{
    public enum IngredientType { Add_Cheese = 1, Add_Bacon, Extra_Meat, Extra_Side }
    public class Menu
    {
        public Menu(int mealNumber, string mealName, string description, IngredientType ingredient, decimal price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Ingredient = ingredient;
            Price = price;
        }
        public Menu()
        {

        }
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public IngredientType Ingredient { get; set; }
        public decimal Price { get; set; }
    }
}
