using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeClasses
{
    public class MenuRepo
    {
        protected readonly List<MenuItem> _itemDirectory = new List<MenuItem>();
        //CRUD
        //CREATE
        public bool AddMenuItem(MenuItem mealName)
        {
            int menuOptions = _itemDirectory.Count;
            _itemDirectory.Add(mealName);

            bool addedItem = _itemDirectory.Count > menuOptions ? true : false;
            return addedItem; 
        }
        //READ
        public List<MenuItem> ListItems()
        {
            return _itemDirectory;
        }
        //UPDATE
        //says not needed at this time

        //DELETE
        public bool RemoveItem(MenuItem meal)
        {
            bool removedItem = _itemDirectory.Remove(meal);
            return removedItem;
        }
        //HELPER 
        public MenuItem RetrieveByMealNumber(int mealNumber)
        {
            foreach(MenuItem item in _itemDirectory)
            {
                if (item.MealNumber == mealNumber)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
