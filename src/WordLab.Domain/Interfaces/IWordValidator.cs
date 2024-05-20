namespace WordLab.Domain.Interfaces
{
    public interface IWordValidator
    {
        Task<bool> IsValidWord(string word);
    }
}