using KomodoCafeClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    class ProgramUI
    {
        private readonly MenuRepo _menuRepo = new MenuRepo();

        public void Run()
        {
            MenuList();
            Menu();
        }
        public void Menu()
        {
           
            bool runProgram = true;
            while (runProgram)
            {
                Console.Clear();
                Console.WriteLine("Please select one of the following options by entering the associated number:\n" + "1. List All Menu Items\n" + "2. Create New Menu Item\n" + "3. Remove A Menu Item\n" + "4. Exit Application\n");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowAllMenuItems();
                        break;
                    case "2":
                        CreateNewItem();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye...\n" +
                            "Press any key to exit.\n");
                        Console.ReadKey();
                        runProgram = false;
                        break;
                    default:
                        Console.WriteLine("Option not valid.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        //option 1: menu directory
        private void ShowAllMenuItems()
        {
            Console.Clear();
            List<MenuItem> listItems = _menuRepo.ListItems();

            foreach (MenuItem item in listItems)
            {
                DisplayMenuItems(item);
                Console.WriteLine("==================");
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        public void DisplayMenuItems(MenuItem item)
        {
            Console.WriteLine($"Meal Number: {item.MealNumber}\n" +
                $"Meal Name: {item.MealName}\n" +
                $"Meal Description: {item.MealDescription}\n" +
                $"Ingredients: {item.ListOfIngredients}\n" +
                $"Meal Price: {item.MealPrice}");
        }
        public void MenuList()
        {
            _menuRepo.AddMenuItem(new MenuItem(1, "Hamburger", "A juicy beef patty layered with freshly sliced cheese and vegetables", "Beef, Tomato, Lettuce, Onion, American Cheese, Sesame Buns", 6.95));
            _menuRepo.AddMenuItem(new MenuItem(2, "Spaghetti", "A bed full of al dente noodles covered our delicious meat sauce.", "Spaghetti Noodles, Beef, Tomato Sauce", 5.45));
            _menuRepo.AddMenuItem(new MenuItem(3, "Chicken Noodle Soup", "A hearty bowl of chicken and noodles that is perfect on a cold winter day.", "Chicken, Carrots, Egg Noodles, Chicken Broth", 3.50));
        }
        //option 2: create menu item
        private void CreateNewItem()
        {
            MenuItem newItem = new MenuItem();
            Console.Write("Please enter the number of the new menu item: ");
            newItem.MealNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the name of the new menu item: ");
            newItem.MealName = Console.ReadLine();
            Console.WriteLine("Please enter a brief description for the menu item.");
            newItem.MealDescription = Console.ReadLine();
            Console.WriteLine("Please list the ingredients.\n" +
                "Ex: Onions, Lettuce, Tomatoes\n ");
            newItem.ListOfIngredients = Console.ReadLine();
            Console.Write("Please enter the price of the item in a decimal format: ");
            newItem.MealPrice = Convert.ToDouble(Console.ReadLine());
            _menuRepo.AddMenuItem(newItem);
            Console.WriteLine("Item successfully added to menu");
        }
        //option 3: delete menu item
        private void DeleteMenuItem()
        {
            Console.Write("Please enter the meal number of the menu item you want to remove: ");
            int mealNumber = Convert.ToInt32(Console.ReadLine());
            MenuItem deletedItem = _menuRepo.RetrieveByMealNumber(mealNumber);
            DisplayMenuItems(deletedItem);
            Console.WriteLine("Are you sure you want to delete this menu item?\n" +
                "YES or NO\n");
            bool evaluateDecision = true;
            while (evaluateDecision)
            {
                string finalizeRemoval = Console.ReadLine().ToUpper();
                switch (finalizeRemoval)
                {
                    case "YES":
                        _menuRepo.RemoveItem(deletedItem);
                        Console.WriteLine("Item has been successfully deleted.\n");
                        evaluateDecision = false;
                        break;
                    case "NO":
                        Console.WriteLine("Item remains in menu.\n");
                        evaluateDecision = false;
                        break;
                    default:
                        Console.WriteLine("Please enter YES or NO");
                        evaluateDecision = true;
                        break;
                }

            }

        }
        // public int MealID
    }
}
