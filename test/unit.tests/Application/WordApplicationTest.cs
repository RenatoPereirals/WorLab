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
        private readonly WordApplication _application;

        public WordApplicationTest()
        {
            _mockSpellCheck = new Mock<ISpellCheckService>();
            _mockWordValidator = new Mock<IWordValidator>();
            _mockWordRepository = new Mock<IWordRepository>();

            _application = new WordApplication(
                _mockSpellCheck.Object,
                _mockWordValidator.Object,
                _mockWordRepository.Object
            );
        }

        [Fact]
        public async Task AddWordAsync_ReturnsTrue_WhenWordIsValidAndAddedSuccessfully()
        {
            // Arrange
            var validWord = "test";
            SetupMocksForValidWord(validWord);

            // Act
            var result = await _application.AddWordAsync(validWord);

            // Assert
            Assert.True(result);
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
        }

        private void SetupMocksForValidWord(string word)
        {
            _mockSpellCheck.Setup(service => service.VerifySpellingAsync(word)).ReturnsAsync(true);
            _mockWordValidator.Setup(validator => validator.IsValidWord(word)).ReturnsAsync(true);
            _mockWordRepository.Setup(repo => repo.AddAsync(word)).ReturnsAsync(true);
        }

        private void SetupMocksForInvalidWord(string word)
        {
            _mockSpellCheck.Setup(service => service.VerifySpellingAsync(word)).ReturnsAsync(false);
            _mockWordValidator.Setup(validator => validator.IsValidWord(word)).ReturnsAsync(false);
        }
    }
}
