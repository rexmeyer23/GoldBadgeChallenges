using KomodoClaimsClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoClaimsTest
{
    [TestClass]
    public class ClaimsTest
    {
        private ClaimRepo _claimRepo;
        [TestInitialize]
        public void Arrange()
        {
            _claimRepo = new ClaimRepo();
        }

        [TestMethod]
        public void Test_FileNewClaim()
        {
            //AAA
            //Arrange
            Claim newClaim = new Claim();
            //Act
            bool result = _claimRepo.FileNewClaim(newClaim);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test_PeekFirstClaim()
        {
            //AAA
            //Arrange
            Claim newItem = new Claim();
            _claimRepo.FileNewClaim(newItem);
            //Act
            Claim claim =_claimRepo.PeekFirstClaim();
            //Assert
            Assert.AreEqual(claim, newItem);
        }
        [TestMethod]
        public void Test_RemoveClaim()
        {
            //AAA
            //Arrange
            Claim newClaim = new Claim();
            _claimRepo.FileNewClaim(newClaim);
            //Act
            Claim claim = _claimRepo.RemoveClaim();
            //Assert
            Assert.AreEqual(claim, newClaim);
        }
        
    }
}
