using System;
using System.Collections.Generic;
using _07_RepositoryPattern_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _07_RepositoryPattern_Tests
{
    [TestClass]
    public class StreamingContentRepositoryTests
    {
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            // Arrange
            StreamingContent content = new StreamingContent();
            StreamingContentRepository repository = new StreamingContentRepository();

            //Act
            bool addResult = repository.AddContentToDirectory(content);

            //Assert
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            //Arrange
            StreamingContent newObject = new StreamingContent();
            StreamingContentRepository repo = new StreamingContentRepository();

            repo.AddContentToDirectory(newObject);

            //Act
            List<StreamingContent> listOfContents = repo.GetContent();

            //Assert
            bool DirectoryHasContent = listOfContents.Contains(newObject);
            Assert.IsTrue(DirectoryHasContent);
        }
        private StreamingContentRepository _repo;
        private StreamingContent _content;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new StreamingContentRepository();
            _content = new StreamingContent("Oceans 8", "do crime?", 100, MaturityRating.PG, true, GenreType.Action);
            _repo.AddContentToDirectory(_content);
        }
        [TestMethod]
        public void GetTitle_ShouldReturnCorrectContent()
        {
            //Arrange
            //Act
            StreamingContent searchResult = _repo.GetContentByTitle("Oceans 8");
            //Assert
            Assert.AreEqual(_content, searchResult);
        }
        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            //Arrange
            StreamingContent updatedContent = new StreamingContent("Italian Job", "do crime?", 100, MaturityRating.PG, true, GenreType.Action);
            //Act
            bool updateResult = _repo.UpdateExistingContent("Oceans 8", updatedContent);
            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            //Arrange
            StreamingContent foundContent = _repo.GetContentByTitle("Oceans 8");
            //Act
            bool removeResult = _repo.DeleteExistingContent(foundContent);
            //Assert
            Assert.IsTrue(removeResult);
        }
    }
}
