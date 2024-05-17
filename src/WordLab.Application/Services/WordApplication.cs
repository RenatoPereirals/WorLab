using WordLab.Application.Interfaces;

namespace WordLab.Application.Services
{
    public class WordApplication(ISpellCheckService spellCheck,
                                 IWordValidator wordValidator)
    {
        private readonly ISpellCheckService _spellCheck = spellCheck ??
            throw new ArgumentNullException(nameof(spellCheck));
        private readonly IWordValidator _wordValidator = wordValidator ??
            throw new ArgumentNullException(nameof(wordValidator));

        public async Task<bool> AddWordAsync(string word)
        {
            if (await _spellCheck.VerifySpellingAsync(word) && await _wordValidator.IsValidWord(word))
                return true;

            return false;
        }
    }
}