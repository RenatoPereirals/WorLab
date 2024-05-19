using WordLab.Domain.Entity;
using WordLab.Domain.Interfaces;

namespace WordLab.Domain.Services
{
    public class WordService(IWordRepository wordRepository) : IWordService
    {
        private readonly IWordRepository _wordRepository = wordRepository ??
            throw new ArgumentException(nameof(wordRepository));
            
        public async Task<ClassifiedWord> ClassifyWordAsync(string word)
        {
            Word objectWord = await _wordRepository.GetWordByWord(word);

            PhoneticSimilarity phoneticSimilarity = WordPhoneticSimilarity(objectWord);
            Context context = WordContext(objectWord);
            GrammaticalType grammaticalType = WordGrammaticalType(objectWord);

            return new ClassifiedWord()
            {
                PhoneticsSimilarities = phoneticSimilarity,
                Contexts = context,
                GrammaticalsTypes = grammaticalType
            };
        }

        public PhoneticSimilarity WordPhoneticSimilarity(Word word)
        {
            return new PhoneticSimilarity();
        }

        public Context WordContext(Word word)
        {
            return new Context();
        }

        public GrammaticalType WordGrammaticalType(Word word)
        {
           return new GrammaticalType();
        }
    }
}