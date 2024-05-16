using Moq;
using Microsoft.AspNetCore.Mvc;
using WordLab.API.Controllers;
using WordLab.API.Interfaces;

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
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, createdAtActionResult.StatusCode);
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
            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestObjectResult.StatusCode);
        }

        [Fact]
        public async Task InsertionWord_ReturnsInternalServerError_WhenExceptionOccurs()
        {
            // Arrange
            var expectedWord = "test";
            _mockWordApplication.Setup(res => res.AddWord(It.IsAny<string>()))
                                .ThrowsAsync(new InvalidOperationException("Erro ao inserir a palavra"));

            // Act
            var wordController = new WordLabController(_mockWordApplication.Object);
            var result = await wordController.InsertionWord(expectedWord);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Equal("Ocorreu um erro interno. Por favor, tente novamente mais tarde. Erro ao inserir a palavra", statusCodeResult.Value);
        }
    }
}
