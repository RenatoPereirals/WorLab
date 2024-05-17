using Moq;
using Microsoft.AspNetCore.Mvc;
using WordLab.API.Controllers;
using WordLab.API.Interfaces;
using Microsoft.Extensions.Logging;

namespace test.unit.tests.API
{
    public class WordLabControllerTest
    {
        private readonly Mock<IWordApplication> _mockWordApplication;
        private readonly Mock<ILogger<WordLabController>> _mockLogger;
        private readonly WordLabController _wordController;

        public WordLabControllerTest()
        {
            _mockWordApplication = new Mock<IWordApplication>();
            _mockLogger = new Mock<ILogger<WordLabController>>();
            _wordController = new WordLabController(_mockWordApplication.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task Post_ReturnsCreatedAtActionResult_WhenWordIsSuccessfullyInserted()
        {
            // Arrange
            var validWord = "test";
            SetupMocksForSuccessfulInsertion(validWord);

            // Act
            var result = await _wordController.Post(validWord);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, createdAtActionResult.StatusCode);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task Post_ReturnsBadRequestObjectResult_WhenWordIsNullOrWhiteSpace(string word)
        {
            // Act
            var result = await _wordController.Post(word);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal("A palavra não pode ser nula ou vazia.", badRequestResult.Value);
        }

        [Fact]
        public async Task Post_ReturnsBadRequestObjectResult_WhenWordIsNotInserted()
        {
            // Arrange
            var invalidWord = "t35t";
            SetupMocksForFailedInsertion(invalidWord);

            // Act
            var result = await _wordController.Post(invalidWord);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async Task Post_ReturnsObjectResultWithInternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            var wordWithException = "test";
            SetupMocksForException(wordWithException, "Erro ao inserir a palavra");

            // Act
            var result = await _wordController.Post(wordWithException);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
        }

        private void SetupMocksForSuccessfulInsertion(string word)
        {
            _mockWordApplication.Setup(service => service.AddWord(word)).ReturnsAsync(true);
        }

        private void SetupMocksForFailedInsertion(string word)
        {
            _mockWordApplication.Setup(service => service.AddWord(word)).ReturnsAsync(false);
        }

        private void SetupMocksForException(string word, string exceptionMessage)
        {
            _mockWordApplication.Setup(service => service.AddWord(word))
                                .ThrowsAsync(new InvalidOperationException(exceptionMessage));
        }
    }
}
