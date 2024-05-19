using System.Net.WebSockets;
using WordLab.Application.Interfaces;
using WordLab.Domain.Entity;
using WordLab.Domain.Interfaces;

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
                throw new ArgumentException("A palavra não pode ser nula ou conter espaços vazios.", nameof(word));

            if (!await _spellCheck.VerifySpellingAsync(word) && !await _wordValidator.IsValidWord(word))
                return false;


            try
            {
                if (await WordExists(word))
                    return false;

                ClassifiedWord WordClassified = await _wordService.ClassifyWordAsync(word);
                var asd = await _wordRepository.AddAsync(WordClassified);

                return asd;
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new ApplicationException("Erro ao classificar a palavra.", ex);
            }
        }

        public async Task<bool> WordExists(string word)
        {
            try
            {
                Word wordName = await _wordRepository.GetWordByWord(word);

                if (wordName.Name.Equals(word, StringComparison.CurrentCultureIgnoreCase))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                // Log de error
                throw new Exception($"Erro ao tentar buscar a palara {word}");
            }
        }
    }
}