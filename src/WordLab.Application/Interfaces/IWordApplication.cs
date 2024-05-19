namespace WordLab.Application.Interfaces
{
    public interface IWordApplication
    {
        Task<bool> AddWord(string word);
        Task<bool> WordExists(string word);
    }
}