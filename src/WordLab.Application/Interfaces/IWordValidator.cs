namespace WordLab.Application.Interfaces
{
    public interface IWordValidator
    {
        Task<bool> IsValidWord(string word);
    }
}