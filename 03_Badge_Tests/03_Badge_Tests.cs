using System;
using System.Collections.Generic;
using _03_Badge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Badge_Tests
{
    [TestClass]
    public class BadgeRepositoryTests

    {
        [TestMethod]
        public void AddDoorToBadge_ShouldGetCorrectBoolean()
        {
            //Arrange
            Badge badge = new Badge();
            BadgeRepository repository = new BadgeRepository();
            //Act
            bool addResult = repository.AddDoorToBadge(badge);
            //Assert
            Assert.IsTrue(addResult);

        }
        [TestMethod]
        public void GetBadges_ShouldReturnCorrectCollection()
        {
            //Arrange
            Badge newBadgeObject = new Badge();
            BadgeRepository repo = new BadgeRepository();
            repo.AddDoorToBadge(newBadgeObject);
            //Act
            List<Badge> listOfBadges = repo.GetBadges();
            //Assert
            bool listHasContent = listOfBadges.Contains(newBadgeObject);
            Assert.IsTrue(listHasContent);
        }
        private Badge _badge;
        private BadgeRepository _repo;

        [TestInitialize]
        
        public void arrange()
        {
            _repo = new BadgeRepository();
            _badge = new Badge("52345", "C1");
            _repo.AddDoorToBadge(_badge);
        }
        [TestMethod]
        public void GetBadgeByID_ShouldReturnCorrectBadge()
        {
            //Arrange, ACT, Assert
            Badge searchResult = _repo.GetBadgeByID("52345");
            Assert.AreEqual(_badge, searchResult);
        }
        [TestMethod]
        public void UpdateExistingBadge_ShouldReturnTrue()
        {
            Badge updatedBadge = new Badge("12345", "C1");
            bool updatedResult = _repo.UpdateExistingBadge("52345", updatedBadge);
            Assert.IsTrue(updatedResult);
        }
        [TestMethod]
        public void DeleteExistingBadge_ShouldReturnTrue()
        {
            Badge foundBadge = _repo.GetBadgeByID("52345");
            bool removeResult = _repo.DeleteExistingBadge(foundBadge);
            Assert.IsTrue(removeResult);
        }
    }
}
