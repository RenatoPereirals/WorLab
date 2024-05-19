using Moq;
using WordLab.Domain.Entity;
using WordLab.Domain.Interfaces;
using WordLab.Domain.Services;

namespace test.unit.tests.Domain.Service
{
    public class WordServiceTest
    {
        private readonly WordService _wordService;
        private readonly Mock<IWordRepository> _mockWordRepository;

        public WordServiceTest()
        {
            _mockWordRepository = new Mock<IWordRepository>();
            _wordService = new WordService(_mockWordRepository.Object);
        }

        [Fact]
        public async Task ClassifyWordAsync_ReturnsClassifiedWord_WhenGivenWord()
        {
            // Arrange
            var word = "test";
            var expectedWord = new Word();
            var expectedPhoneticSimilarity = new PhoneticSimilarity();
            var expectedContext = new Context();
            var expectedGrammaticalType = new GrammaticalType();

            _mockWordRepository.Setup(repo => repo.GetWordByWord(word)).ReturnsAsync(expectedWord);

            // Act
            var result = await _wordService.ClassifyWordAsync(word);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ClassifiedWord>(result);
        }
    }
}