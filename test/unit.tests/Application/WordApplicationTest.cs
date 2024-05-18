using Moq;
using WordLab.Application.Interfaces;
using WordLab.Application.Services;

namespace test.unit.tests.Application
{
    public class WordApplicationTest
    {
        private readonly Mock<ISpellCheckService> _mockSpellCheck;
        private readonly Mock<IWordValidator> _mockWordValidator;
        private readonly Mock<IWordRepository> _mockWordRepository;
        private readonly Mock<IWordService> _mockWordService;
        private readonly WordApplication _application;

        public WordApplicationTest()
        {
            _mockSpellCheck = new Mock<ISpellCheckService>();
            _mockWordValidator = new Mock<IWordValidator>();
            _mockWordRepository = new Mock<IWordRepository>();
            _mockWordService = new Mock<IWordService>();

            _application = new WordApplication(
                _mockSpellCheck.Object,
                _mockWordValidator.Object,
                _mockWordRepository.Object,
                _mockWordService.Object
            );
        }

        [Fact]
        public async Task AddWordAsync_ReturnsTrue_WhenWordIsValidAndAddedSuccessfully()
        {
            // Arrange
            var validWord = "test";
            var classifiedWord = "classifiedTest";
            SetupMocksForValidWord(validWord, classifiedWord);

            // Act
            var result = await _application.AddWordAsync(validWord);

            // Assert
            Assert.True(result);
            _mockWordService.Verify(service => service.ClassifyWordAsync(It.Is<string>(w => w == validWord)), Times.Once);
            _mockWordRepository.Verify(repo => repo.AddAsync(It.Is<string>(w => w == classifiedWord)), Times.Once);
        }

        [Fact]
        public async Task AddWordAsync_ReturnsFalse_WhenWordIsInvalid()
        {
            // Arrange
            var invalidWord = "t35t";
            SetupMocksForInvalidWord(invalidWord);

            // Act
            var result = await _application.AddWordAsync(invalidWord);

            // Assert
            Assert.False(result);
            _mockWordService.Verify(service => service.ClassifyWordAsync(It.IsAny<string>()), Times.Never);
            _mockWordRepository.Verify(repo => repo.AddAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task AddWordAsync_ReturnsFalse_WhenClassifyWordAsyncThrowsException()
        {
            // Arrange
            var validWord = "test";
            var classifiedWord = "classifiedTest";
            SetupMocksForValidWord(validWord, classifiedWord);
            _mockWordService.Setup(service => service.ClassifyWordAsync(It.IsAny<string>())).ThrowsAsync(new Exception("Erro ao classificar a palavra"));

            // Act
            var result = await _application.AddWordAsync(validWord);

            // Assert
            Assert.False(result);
        }

        private void SetupMocksForValidWord(string word, string classifiedWord)
        {
            _mockSpellCheck.Setup(service => service.VerifySpellingAsync(word)).ReturnsAsync(true);
            _mockWordValidator.Setup(validator => validator.IsValidWord(word)).ReturnsAsync(true);
            _mockWordService.Setup(service => service.ClassifyWordAsync(word)).ReturnsAsync(classifiedWord);
            _mockWordRepository.Setup(repo => repo.AddAsync(classifiedWord)).ReturnsAsync(true);
        }

        private void SetupMocksForInvalidWord(string word)
        {
            _mockSpellCheck.Setup(service => service.VerifySpellingAsync(word)).ReturnsAsync(false);
            _mockWordValidator.Setup(validator => validator.IsValidWord(word)).ReturnsAsync(false);
        }
    }
}
