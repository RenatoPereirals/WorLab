using WordLab.Domain.Entity;
using WordLab.Domain.Interfaces;

namespace WordLab.Domain.Services
{
    public class WordService(IWordRepository wordRepository) : IWordService
    {
        private readonly IWordRepository _wordRepository = wordRepository ??
            throw new ArgumentNullException(nameof(wordRepository));

        public async Task<ClassifiedWord> ClassifyWordAsync(string word)
        {
            var objectWord = await _wordRepository.GetWordByWord(word);
            return new ClassifiedWord
            {
                PhoneticsSimilarities = CreatePhoneticSimilarity(objectWord),
                Contexts = CreateContext(objectWord),
                GrammaticalsTypes = CreateGrammaticalType(objectWord)
            };
        }

        private static PhoneticSimilarity CreatePhoneticSimilarity(Word word)
        {
            return new PhoneticSimilarity();
        }

        private static Context CreateContext(Word word)
        {
            return new Context();
        }

        private static GrammaticalType CreateGrammaticalType(Word word)
        {
            return new GrammaticalType();
        }
    }
}
