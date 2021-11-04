using KomodoBadgesClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoBadgesTest
{
    [TestClass]
    public class BadgesTest
    {
        private BadgeRepo _badgeRepo;
        private Badge _badge;
        [TestInitialize]
        public void Arrange()
        {
            _badgeRepo = new BadgeRepo();
            _badge = new Badge(12345, new List<string> { "A7" }, "Numero Uno");
        }
        [TestMethod]
        public void Test_CreateNewBadge()
        {
            //AAA
            //Arrange
            Badge badge = new Badge();
            //Act
            bool result = _badgeRepo.CreateNewBadge(badge);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test_AddDoorToBadge()
        {
            //AAA
            //Arrange
            _badgeRepo.CreateNewBadge(_badge);
            string newDoor = "A1";
            //Act
            bool doorAdded = _badgeRepo.AddDoorToBadge(_badge.BadgeID, newDoor);
            //Assert
            Assert.IsTrue(doorAdded);
        }
        [TestMethod]
        public void Test_RemoveDoorFromBadge()
        {
            //AAA
            //Arrange
            _badgeRepo.CreateNewBadge(_badge);
            string oldDoor = "A7";
            //Act
            bool doorRemoved = _badgeRepo.RemoveDoorFromBadge(_badge.BadgeID, oldDoor);
            //Assert
            Assert.IsTrue(doorRemoved);
        }
        [TestMethod]
        public void Test_DeleteAllDoorsFromBadge()
        {
            //AAA
            //Arrange
            _badgeRepo.CreateNewBadge(_badge);
            //Act
            bool allDoorsRemoved = _badgeRepo.DeleteAllDoorsFromBadge(_badge.BadgeID);
            //Assert
            Assert.IsTrue(allDoorsRemoved);
        }
        [TestMethod]
        public void Test_RetrieveByID()
        {
            //AAA
            //Arrange
            _badgeRepo.CreateNewBadge(_badge);
            
            //Act
            Badge actual = _badgeRepo.RetrieveByID(12345);
            Badge expected = _badge;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
