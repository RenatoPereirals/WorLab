namespace WordLab.Application.Interfaces
{
    public interface IWordService
    {
        Task<string> ClassifyWordAsync(string word);
    }
}