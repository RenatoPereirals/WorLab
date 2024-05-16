using Moq;
using Microsoft.AspNetCore.Mvc;
using WordLab.API.Controllers;
using WordLab.API.Interfaces;
using Xunit;

namespace test.unit.tests.API
{
    public class WordLabControllerTest
    {
        private readonly Mock<IWordApplication> _mockWordApplication;

        public WordLabControllerTest()
        {
            _mockWordApplication = new Mock<IWordApplication>();
        }

        [Fact]
        public async Task InsertionWord_ReturnsSuccessWithStatusCode201_WhenWordInserted()
        {
            // Arrange
            var expectedWord = "test";
            _mockWordApplication.Setup(res => res.AddWord(expectedWord)).ReturnsAsync(true);

            // Act
            var wordController = new WordLabController(_mockWordApplication.Object);
            var result = await wordController.InsertionWord(expectedWord);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(201, (result as StatusCodeResult)?.StatusCode);
        }

        [Fact]
        public async Task InsertionWord_ReturnsBadRequest_WhenWordInsertedIsNullOrEmpty()
        {
            // Arrange
            var wordController = new WordLabController(_mockWordApplication.Object);
            string? nullWord = null;
            string emptyWord = "";

            // Act
            var resultForNullWord = await wordController.InsertionWord(nullWord!) as BadRequestObjectResult;
            var resultForEmptyWord = await wordController.InsertionWord(emptyWord) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(resultForNullWord);
            Assert.NotNull(resultForEmptyWord);
            Assert.Equal(400, resultForNullWord.StatusCode);
            Assert.Equal(400, resultForEmptyWord.StatusCode);
            Assert.Equal("A palavra não pode ser nula ou vazia.", resultForNullWord.Value);
            Assert.Equal("A palavra não pode ser nula ou vazia.", resultForEmptyWord.Value);
        }

        [Fact]
        public async Task InsertionWord_ReturnsBadRequest_WhenWordNotInserted()
        {
            // Arrange
            var expectedWord = "t35t";
            _mockWordApplication.Setup(res => res.AddWord(expectedWord)).ReturnsAsync(false);

            // Act            
            var wordController = new WordLabController(_mockWordApplication.Object);
            var result = await wordController.InsertionWord(expectedWord);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(400, (result as StatusCodeResult)?.StatusCode);
        }

        [Fact]
        public async Task InsertionWord_ReturnsInternalServerError_WhenExceptionOccurs()
        {
            // Arrange
            var expectedWord = "test";
            _mockWordApplication.Setup(res => res.AddWord(It.IsAny<string>())).ThrowsAsync(new Exception("Erro ao inserir a palavra"));

            // Act            
            var wordController = new WordLabController(_mockWordApplication.Object);
            var result = await wordController.InsertionWord(expectedWord);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, (result as StatusCodeResult)?.StatusCode);
        }
    }
}
