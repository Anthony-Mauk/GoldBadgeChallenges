using System;
using System.Collections.Generic;
using _02_Claim;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KClaim = _02_Claim.KClaim;

namespace _02_ClaimContentTests
{
    [TestClass]
    public class ClaimContentTests
    {
        //1. See all claims
        //2. Take care of next claim
        //3. Enter a new claim
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            //Arrange
            KClaim claim = new KClaim();
            ClaimRepository repository = new ClaimRepository();
            //Act
            bool addResult = repository.AddClaimToDirectory(claim);
            //Assert
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetClaim_ShouldReturnCorrectCollection()
        {
            //Arrange
            KClaim newObject = new KClaim();
            ClaimRepository repo = new ClaimRepository();
            repo.AddClaimToDirectory(newObject);
            //Act
            List<KClaim> listOfClaims = repo.GetClaims();
            //Assert
            bool directoryHasClaims = listOfClaims.Contains(newObject);
            Assert.IsTrue(directoryHasClaims);
        }
        public void DeleteClaim_ShouldReturnTrue()
        {
            //KClaim foundClaim = _repo.
        }
        //GetNexClaim - then dequeue
        private ClaimRepository _repo;
        private KClaim _claim;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepository();
           //start here...
        }
    }
}
