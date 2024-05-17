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

        public WordApplicationTest()
        {
            _mockSpellCheck = new Mock<ISpellCheckService>();
            _mockWordValidator = new Mock<IWordValidator>();
            _mockWordRepository = new Mock<IWordRepository>();
        }

        [Fact]
        public async Task AddWordAsync_ShouldReturnTrue_WhenWordIsAdded()
        {
            // Arrage
            var wordToAdd = "test";
            var application = new WordApplication(_mockSpellCheck.Object, _mockWordValidator.Object, _mockWordRepository.Object);
            _mockSpellCheck.Setup(res => res.VerifySpellingAsync(wordToAdd)).ReturnsAsync(true);
            _mockWordValidator.Setup(res => res.IsValidWord(wordToAdd)).ReturnsAsync(true);
            _mockWordRepository.Setup(res => res.AddAsync(wordToAdd)).ReturnsAsync(true);

            // Act
            var result = await application.AddWordAsync(wordToAdd);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task AddWordAsync_ShouldReturnTrue_WhenWordIsValid()
        {
            // Arrage
            var wordToAdd = "t35t";
            var application = new WordApplication(_mockSpellCheck.Object, _mockWordValidator.Object, _mockWordRepository.Object);
            _mockSpellCheck.Setup(res => res.VerifySpellingAsync(wordToAdd)).ReturnsAsync(true);
            _mockWordValidator.Setup(res => res.IsValidWord(wordToAdd)).ReturnsAsync(true);
            _mockWordRepository.Setup(res => res.AddAsync(wordToAdd)).ReturnsAsync(true);

            // Act
            var result = await application.AddWordAsync(wordToAdd);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task AddWordAsync_ShouldReturnFalse_WhenWordIsInvalid()
        {
            // Arrage
            var wordToAdd = "t35t";
            var application = new WordApplication(_mockSpellCheck.Object, _mockWordValidator.Object, _mockWordRepository.Object);
            _mockSpellCheck.Setup(res => res.VerifySpellingAsync(wordToAdd)).ReturnsAsync(false);
            _mockWordValidator.Setup(res => res.IsValidWord(wordToAdd)).ReturnsAsync(false);

            // Act
            var result = await application.AddWordAsync(wordToAdd);

            // Assert
            Assert.False(result);
        }
    }
}