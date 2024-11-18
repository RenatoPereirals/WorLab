using WordLab.Domain.Entity;
using WordLab.Domain.Interfaces;

using WordLab.Application.Exceptions;

namespace WordLab.Application.Services;

public class WordApplication(ISpellCheckService spellCheck,
                             IWordValidator wordValidator,
                             IWordRepository wordRepository,
                             IWordService wordService)
{
    private readonly ISpellCheckService _spellCheck = spellCheck ?? throw new ArgumentNullException(nameof(spellCheck));

    private readonly IWordValidator _wordValidator = wordValidator ?? throw new ArgumentNullException(nameof(wordValidator));

    private readonly IWordRepository _wordRepository = wordRepository ?? throw new ArgumentNullException(nameof(wordRepository));

    private readonly IWordService _wordService = wordService ?? throw new ArgumentNullException(nameof(wordService));

    public async Task<bool> AddWordAsync(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            throw new ArgumentException("The word cannot be null or contain empty spaces.", nameof(word));

        if (!await _spellCheck.VerifySpellingAsync(word) && !await _wordValidator.IsValidWord(word))
            return false;

        try
        {
            if (await WordExists(word))
                return false;

            ClassifiedWord classifiedWord = await _wordService.ClassifyWordAsync(word);
            return await _wordRepository.AddAsync(classifiedWord);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding the word: {ex.Message}");
            throw new ApplicationException("Error classifying the word.", ex);
        }
    }

    public async Task<bool> WordExists(string word)
    {
        try
        {
            if (string.IsNullOrEmpty(word))
                throw new ArgumentNullException(nameof(word), "The word cannot be null or contain empty spaces.");

            Word wordName = await _wordRepository.GetWordByWord(word);

            if (wordName != null && wordName.Name.Equals(word, StringComparison.CurrentCultureIgnoreCase))
                return true;

            return false;
        }
        catch (WordApplicationException ex)
        {
            Console.WriteLine($"Error checking if the word exists: {ex.Message}");
            throw new WordApplicationException("An internal error occurred, please try again later.");
        }
    }
}
