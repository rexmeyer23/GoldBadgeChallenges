using KomodoCafeClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafeTest
{
    [TestClass]
    public class MenuTest
    {
        //[TestInitialize]
        //private MenuRepo _menuRepo;
        //public void Arrange()
        //{
        //    _menuRepo = new MenuRepo();
        //}
        [TestMethod]
        public void Test_AddMenuItem()
        {
            //AAA
            //Arrange
            MenuRepo _menuRepo = new MenuRepo();
            MenuItem itemOne = new MenuItem();
            //Act
            bool result = _menuRepo.AddMenuItem(itemOne);
            //Assert
            Assert.IsTrue(result);
        }
        //[TestMethod]
        //public void Test_ListItems()
        //{
        //    //AAA
        //    //Arrange
        //    MenuRepo _repo
        //}
        //[TestMethod]
        //public void Test_RemoveItem()
        //{
        //    //AAA
        //    //Arrange
        //    MenuItem item = new MenuItem();
        //    item.MealName = "burger";
        //    _menuRepo.AddMenuItem(item);
        //    //Act
        //    bool actual = _menuRepo.RemoveItem(item);
        //    bool expected = true;
        //    //Assert
        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void Test_RetrieveByMealNumber()
        //{
        //  //AAA
        //    //Arrange
        //   MenuRepo _menuRepo = new MenuRepo();
        //  MenuItem meal = new MenuItem(int mealNumber);
        //   meal.MealNumber = 2;

        //    //Act
        //    bool actual = _menuRepo.RetrieveByMealNumber(2);
        //   bool expected = meal;
        //   //Assert
        //    Assert.AreEqual(expected, actual);
        //}

    }
}

