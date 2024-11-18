using Moq;
using Microsoft.AspNetCore.Mvc;
using WordLab.API.Controllers;
using Microsoft.Extensions.Logging;
using WordLab.Application.Interfaces;
using WordLab.Application.Models;

namespace Test.Unit.Tests.API
{
    public class WordLabControllerTest
    {
        private readonly Mock<IWordApplication> _wordApplicationMock;
        private readonly Mock<ILogger<WordLabController>> _mockLogger;
        private readonly WordLabController _wordController;

        public WordLabControllerTest()
        {
            _wordApplicationMock = new Mock<IWordApplication>();
            _mockLogger = new Mock<ILogger<WordLabController>>();
            _wordController = new WordLabController(_wordApplicationMock.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task Post_ReturnsCreatedAtActionResult_WhenWordIsSuccessfullyInserted()
        {
            // Arrange
            var validWord = "test";
            var word = new WordModel { Word = validWord };

            SetupMockForSuccessfulInsertion(validWord);

            // Act
            var result = await _wordController.Post(word);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, createdAtActionResult.StatusCode);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task Post_ReturnsBadRequestObjectResult_WhenWordIsNullOrWhiteSpace(string? invalidWord)
        {
            // Act
            var word = new WordModel { Word = invalidWord ?? string.Empty };
            var result = await _wordController.Post(word);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal("The word cannot be null or contain empty spaces.", badRequestResult.Value);
        }

        [Fact]
        public async Task Post_ReturnsConflictObjectResult_WhenWordExists()
        {
            // Arrange
            var wordExists = "test";
            var word = new WordModel { Word = wordExists};

            _wordApplicationMock.Setup(app => app.WordExists(wordExists)).ReturnsAsync(true);
            var result = await _wordController.Post(word);

            // Assert
            var badRequestResult = Assert.IsType<ConflictObjectResult>(result);
            Assert.Equal(409, badRequestResult.StatusCode);
            Assert.Equal($"The word {wordExists} already exists.", badRequestResult.Value);
        }

        [Fact]
        public async Task Post_ReturnsBadRequestObjectResult_WhenWordIsNotInserted()
        {
            // Arrange
            
            var invalidWord = "t35t";
            var word = new WordModel { Word = invalidWord };

            SetupMockForFailedInsertion(invalidWord);

            // Act
            var result = await _wordController.Post(word);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async Task Post_ReturnsObjectResultWithInternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            var wordWithException = "test";
            var word = new WordModel { Word = wordWithException };

            SetupMockForException(wordWithException, "Error inserting the word.");

            // Act
            var result = await _wordController.Post(word);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
        }

        private void SetupMockForSuccessfulInsertion(string word)
        {
            _wordApplicationMock.Setup(service => service.AddWord(word)).ReturnsAsync(true);
        }

        private void SetupMockForFailedInsertion(string word)
        {
            _wordApplicationMock.Setup(service => service.AddWord(word)).ReturnsAsync(false);
        }

        private void SetupMockForException(string word, string exceptionMessage)
        {
            _wordApplicationMock.Setup(service => service.AddWord(word))
                                .ThrowsAsync(new InvalidOperationException(exceptionMessage));
        }
    }
}
