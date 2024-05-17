namespace WordLab.Application.Interfaces
{
    public interface IWordRepository
    {
        Task<bool> AddAsync(string word);
    }
}