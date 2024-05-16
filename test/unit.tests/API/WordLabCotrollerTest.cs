using Moq;

using Microsoft.AspNetCore.Mvc;

using WordLab.API.Controllers;
using WordLab.API.Interfaces;
using Xunit.Sdk;

namespace test.unit.tests.API
{
    public class WordLabCotrollerTest
    {
        private readonly Mock<IWordApplication> _mockWordApplication;

        public WordLabCotrollerTest()
        {
            _mockWordApplication = new Mock<IWordApplication>();
        }

        [Fact]
        public async void InsertWord_WhenWordInserted_ReturnsSuccessWithStatusCode201()
        {
            // Arrange
            var expectedWord = "test";
            _mockWordApplication.Setup(res => res.AddWord(expectedWord)).ReturnsAsync(true);

            // Act
            var wordController = new WordLabController(_mockWordApplication.Object);
            var result = await wordController.InsertionWord(expectedWord);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var statusCodeResult = (StatusCodeResult)result;
            Assert.Equal(201, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void InsertWord_WhenWordInserted_ReturnsExceptionWithStatusCode400()
        {
            // Arrange
            var expectedWord = "t35t";
            _mockWordApplication.Setup(res => res.AddWord(expectedWord)).ReturnsAsync(false);

            // Act            
            var wordController = new WordLabController(_mockWordApplication.Object);
            var result = await wordController.InsertionWord(expectedWord);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var statusCodeResult = (StatusCodeResult)result;
            Assert.Equal(400, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void InsertWord_WhenWordInserted_ReturnsExceptionWithStatusCode500()
        {
            // Arrange
            var expectedWord = "test";
            _mockWordApplication.Setup(res => res.AddWord(It.IsAny<string>())).ThrowsAsync(new Exception("Erro ao inserir a palavra"));

            // Act            
            var wordController = new WordLabController(_mockWordApplication.Object);
            var result = await wordController.InsertionWord(expectedWord);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var statusCodeResult = (StatusCodeResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}