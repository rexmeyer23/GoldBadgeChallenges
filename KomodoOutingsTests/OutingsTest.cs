using KomodoOutingsClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoOutingsTests
{
    [TestClass]
    public class OutingsTest
    {
        private OutingRepo _outingRepo;
        [TestInitialize]
        public void Arrange()
        {
            _outingRepo = new OutingRepo();
        }
        [TestMethod]
        public void Test_CreateNewOuting()
        {
            //AAA
            //Arrange
            Outing outing = new Outing();
            //Act
            bool result = _outingRepo.CreateOuting(outing);
            //Assert
            Assert.IsTrue(result);
        }

    }
}
