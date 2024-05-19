using WordLab.Domain.Entity;

namespace WordLab.Domain.Interfaces
{
    public interface IWordRepository
    {
        Task<bool> AddAsync(ClassifiedWord word);
        Task<Word> GetWordByWord(string word);
    }
}