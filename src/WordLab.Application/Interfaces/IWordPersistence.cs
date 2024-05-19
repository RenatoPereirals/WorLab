namespace WordLab.Application.Interfaces
{
    public interface IWordPersistence
    {
        Task<bool> GetWordByWord(string word);
    }
}