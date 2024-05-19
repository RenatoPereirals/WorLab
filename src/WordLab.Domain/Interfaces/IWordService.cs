using WordLab.Domain.Entity;

namespace WordLab.Domain.Interfaces
{
    public interface IWordService
    {
        Task<ClassifiedWord> ClassifyWordAsync(string word);
    }
}