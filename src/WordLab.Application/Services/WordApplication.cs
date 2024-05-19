using WordLab.Application.Interfaces;

namespace WordLab.Application.Services
{
    public class WordApplication(ISpellCheckService spellCheck,
                                 IWordValidator wordValidator,
                                 IWordRepository wordRepository,
                                 IWordService wordService)
    {
        private readonly ISpellCheckService _spellCheck = spellCheck ??
            throw new ArgumentNullException(nameof(spellCheck));
        private readonly IWordValidator _wordValidator = wordValidator ??
            throw new ArgumentNullException(nameof(wordValidator));
        private readonly IWordRepository _wordRepository = wordRepository ??
            throw new ArgumentNullException(nameof(wordRepository));
        private readonly IWordService _wordService = wordService ??
            throw new ArgumentNullException(nameof(wordService));

        public async Task<bool> AddWordAsync(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentException("A palavra não pode ser nula ou conter espaços vazios.", nameof(word));
            }

            if (!await _spellCheck.VerifySpellingAsync(word) && !await _wordValidator.IsValidWord(word))
                return false;

            try
            {
                var WordClassified = await _wordService.ClassifyWordAsync(word);
                return await _wordRepository.AddAsync(WordClassified);
            }
            catch (Exception ex)
            {
                // Log the exception (logging not shown here)
                throw new ApplicationException("Erro ao classificar a palavra.", ex);
            }
        }
    }
}