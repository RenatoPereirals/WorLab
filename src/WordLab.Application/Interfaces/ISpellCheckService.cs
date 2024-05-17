namespace WordLab.Application.Interfaces
{
    public interface ISpellCheckService
    {
        Task<bool> VerifySpellingAsync(string word);
    }
}