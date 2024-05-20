namespace WordLab.Domain.Interfaces
{
    public interface ISpellCheckService
    {
        Task<bool> VerifySpellingAsync(string word);
    }
}