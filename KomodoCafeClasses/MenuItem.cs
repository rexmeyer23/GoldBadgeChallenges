using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeClasses
{
    public class MenuItem
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string ListOfIngredients { get; set; }
        public double MealPrice { get; set; }
        public MenuItem()
        {

        }
        public MenuItem(int mealNumber, string mealName, string mealDescription, string listOfIngredients, double mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            ListOfIngredients = listOfIngredients;
            MealPrice = mealPrice;
        }


    }
}
