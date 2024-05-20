using Moq;
using WordLab.Application.Interfaces;
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
        private readonly WordApplication _application;

        public WordApplicationTest()
        {
            _mockSpellCheck = new Mock<ISpellCheckService>();
            _mockWordValidator = new Mock<IWordValidator>();
            _mockWordRepository = new Mock<IWordRepository>();
            _mockWordService = new Mock<IWordService>();
            _mockWordService = new Mock<IWordService>();

            _application = new WordApplication(
                _mockSpellCheck.Object,
                _mockWordValidator.Object,
                _mockWordRepository.Object,
                _mockWordService.Object
            );
        }

        [Theory]
        [InlineData(null)]
        [InlineData("     ")]
        public async Task AddWordAsync_ThrowsArgumentException_WhenWordIsNullOrWhiteSpace(string word)
        {
            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _application.AddWordAsync(word));
            Assert.Contains("A palavra não pode ser nula ou conter espaços vazios.", exception.Message);
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
            bool result = await _application.AddWordAsync(validWord);

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
            bool result = await _application.AddWordAsync(validWord);

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
            var result = await _application.AddWordAsync(invalidWord);

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
            var result = await _application.AddWordAsync(existingWord);

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
                            .ThrowsAsync(new ApplicationException("Erro ao classificar a palavra"));

            _mockWordRepository.Setup(repo => repo.GetWordByWord(It.IsAny<string>()))
                               .ReturnsAsync(new Word { Name = "differentWord" });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApplicationException>(() => _application.AddWordAsync(validWord));
            Assert.Equal("Erro ao classificar a palavra.", exception.Message);
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
