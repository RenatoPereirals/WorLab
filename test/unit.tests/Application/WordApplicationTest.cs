using Moq;
using WordLab.Application.Services;
using WordLab.Domain.Entity;
using WordLab.Domain.Interfaces;

namespace test.unit.tests.Application
{
    public class WordApplicationTest
    {
        private readonly Mock<ISpellCheckService> _mockSpellCheck;
        private readonly Mock<IWordValidator> _mockWordValidator;
        private readonly Mock<IWordRepository> _mockWordRepository;
        private readonly Mock<IWordService> _mockWordService;
        private readonly WordApplication _wordApplication;

        public WordApplicationTest()
        {
            _mockSpellCheck = new Mock<ISpellCheckService>();
            _mockWordValidator = new Mock<IWordValidator>();
            _mockWordRepository = new Mock<IWordRepository>();
            _mockWordService = new Mock<IWordService>();
            _mockWordService = new Mock<IWordService>();

            _wordApplication = new WordApplication(
                _mockSpellCheck.Object,
                _mockWordValidator.Object,
                _mockWordRepository.Object,
                _mockWordService.Object
            );
        }

        [Theory]
        [InlineData(null)]
        [InlineData("     ")]
        public async Task AddWordAsync_ThrowsArgumentException_WhenWordIsNullOrWhiteSpace(string? word)
        {
            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _wordApplication.AddWordAsync(word ?? string.Empty));
            Assert.Contains("The word cannot be null or contain empty spaces.", exception.Message);
        }

        [Fact]
        public async Task AddWordAsync_ReturnsTrue_WhenWordIsValidAndDoesNotExist()
        {
            // Arrange
            var validWord = "word";
            SetupMocksForValidWord(validWord);

            _mockWordRepository.Setup(repo => repo.GetWordByWord(It.IsAny<string>()))
                               .ReturnsAsync(new Word { Name = "differentWord" });
            // Act
            bool result = await _wordApplication.AddWordAsync(validWord);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task AddWordAsync_ReturnsFalse_WhenWordIsValidAndExist()
        {
            // Arrange
            var validWord = "word";
            SetupMocksForValidWord(validWord);

            _mockWordRepository.Setup(repo => repo.GetWordByWord(It.IsAny<string>()))
                               .ReturnsAsync(new Word { Name = "word" });
            // Act
            bool result = await _wordApplication.AddWordAsync(validWord);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task AddWordAsync_ReturnsFalse_WhenWordIsInvalid()
        {
            // Arrange
            var invalidWord = "t35t";
            SetupMocksForInvalidWord(invalidWord);

            // Act
            var result = await _wordApplication.AddWordAsync(invalidWord);

            // Assert
            Assert.False(result);
            _mockWordService.Verify(service => service.ClassifyWordAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task AddWordAsync_ReturnsFalse_WhenWordExists()
        {
            // Arrange
            var existingWord = "test";
            SetupMocksForWordExists(existingWord);

            // Act
            var result = await _wordApplication.AddWordAsync(existingWord);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task AddWordAsync_ReturnsException_WhenClassifyWordAsyncThrowsException()
        {
            // Arrange
            var validWord = "word";
            SetupMocksForValidWord(validWord);
            _mockWordService.Setup(service => service.ClassifyWordAsync(It.IsAny<string>()))
                            .ThrowsAsync(new ApplicationException("Error classifying the word."));

            _mockWordRepository.Setup(repo => repo.GetWordByWord(It.IsAny<string>()))
                               .ReturnsAsync(new Word { Name = "differentWord" });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApplicationException>(() => _wordApplication.AddWordAsync(validWord));
            Assert.Equal("Error classifying the word.", exception.Message);
        }

        [Fact]
        public async Task WordExists_ShouldThrowArgumentNullException_WhenWordIsNullOrEmpty()
        {
            // Arrange
            string? word = null;

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _wordApplication.WordExists(word ?? string.Empty));
            Assert.Equal("word", exception.ParamName);
        }

        [Fact]
        public async Task WordExists_ShouldReturnTrue_WhenWordExists()
        {
            // Arrange
            string word = "example";
            _mockWordRepository.Setup(repo => repo.GetWordByWord(word))
                               .ReturnsAsync(new Word { Name = word });

            // Act
            bool result = await _wordApplication.WordExists(word);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task WordExists_ShouldReturnFalse_WhenWordNotExists()
        {
            // Arrange
            string word = "example";
            _mockWordRepository.Setup(repo => repo.GetWordByWord(It.IsAny<string>()))
                               .ReturnsAsync(new Word());

            // Act
            bool result = await _wordApplication.WordExists(word);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task WordExists_ShouldThrowException_WhenRepositoryThrowsException()
        {
            // Arrange
            string word = "example";
            _mockWordRepository.Setup(repo => repo.GetWordByWord(word))
                               .ThrowsAsync(new Exception("An internal error occurred, please try again later."));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _wordApplication.WordExists(word));
            Assert.Equal("An internal error occurred, please try again later.", exception.Message);
        }

        private void SetupMocksForValidWord(string word)
        {
            var newWord = new ClassifiedWord();
            _mockSpellCheck.Setup(service => service.VerifySpellingAsync(word))
                                                    .ReturnsAsync(true);

            _mockWordValidator.Setup(validator => validator.IsValidWord(word))
                                                           .ReturnsAsync(true);

            _mockWordService.Setup(service => service.ClassifyWordAsync(word))
                                                     .Returns(Task.FromResult(newWord));

            _mockWordRepository.Setup(repo => repo.AddAsync(It.IsAny<ClassifiedWord>()))
                                                  .ReturnsAsync(true);
        }

        private void SetupMocksForInvalidWord(string word)
        {
            _mockSpellCheck.Setup(service => service.VerifySpellingAsync(word)).ReturnsAsync(false);
            _mockWordValidator.Setup(validator => validator.IsValidWord(word)).ReturnsAsync(false);
            _mockWordRepository.Setup(repo => repo.GetWordByWord(It.IsAny<string>()))
                                                  .ReturnsAsync(new Word());
        }

        private void SetupMocksForWordExists(string word)
        {
            var newWord = new Word();
            _mockWordRepository.Setup(validator => validator.GetWordByWord(word)).Returns(Task.FromResult(newWord));
        }
    }
}
