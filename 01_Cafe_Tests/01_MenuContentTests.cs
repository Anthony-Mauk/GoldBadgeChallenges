using System;
using System.Collections.Generic;
using _01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Cafe_Tests
{
    [TestClass]
    public class MenuContentTests
    {
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            //arrange
            MenuContent content = new MenuContent();
            MenuContentRepository repository = new MenuContentRepository();
            //act
            bool addResult = repository.AddContentToDirectory(content);
            //assert
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            //Arrange, Act Assert
            MenuContent newObject = new MenuContent();
            MenuContentRepository repo = new MenuContentRepository();
            repo.AddContentToDirectory(newObject);
            List<MenuContent> listOfContents = repo.GetContents();
            bool directoryHasContent = listOfContents.Contains(newObject);
            Assert.IsTrue(directoryHasContent);
        }
        private MenuContentRepository _repo;
        private MenuContent _content;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuContentRepository();
            _content = new MenuContent("1", "Pizza", "Thick crust pepperoni pizza", "Dough, Sauce, Pizza", "12.00");
            _repo.AddContentToDirectory(_content);
        }
        
        [TestMethod]
        public void GetbyNumber_ShouldReturnCorrectContent()
        {
            MenuContent searchResult = _repo.GetContentItemByMenuNumber("1");
            Assert.AreEqual(_content, searchResult);
        }
        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            //AAA
            MenuContent foundContent = _repo.GetContentItemByMenuNumber("1");
            bool removeResult = _repo.DeleteExistingContent(foundContent);
            Assert.IsTrue(removeResult);
        }
    }
}
