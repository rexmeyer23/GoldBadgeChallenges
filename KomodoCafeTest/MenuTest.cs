using KomodoCafeClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace KomodoCafeTest
{
    [TestClass]
    public class MenuTest
    {
        private MenuRepo _menuRepo;
        [TestInitialize]
        public void Arrange()
        {
            _menuRepo = new MenuRepo();
        }
        [TestMethod]
        public void Test_AddMenuItem()
        {
            //AAA
            //Arrange
            MenuItem itemOne = new MenuItem();
            //Act
            bool result = _menuRepo.AddMenuItem(itemOne);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]

        public void Test_RemoveItem()
        {
            //AAA
            //Arrange

            MenuItem item = new MenuItem();
            _menuRepo.AddMenuItem(item);
            //Act
            bool actual = _menuRepo.RemoveItem(item);
            bool expected = true;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_RetrieveByMealNumber()
        {
            //AAA
            //Arrange
            MenuItem meal = new MenuItem();
            meal.MealNumber = 2;
            _menuRepo.AddMenuItem(meal);

            //Act
            MenuItem actual = _menuRepo.RetrieveByMealNumber(2);
            MenuItem expected = meal;
            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}

