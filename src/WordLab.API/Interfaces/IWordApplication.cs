namespace WordLab.API.Interfaces
{
    public interface IWordApplication 
    {
        Task<bool> AddWord(string word);
     }
}