namespace WordLab.Application.Exceptions;

[Serializable]
internal class WordApplicationException : Exception
{
    public WordApplicationException()
    {
    }

    public WordApplicationException(string? message) : base(message)
    {
    }

    public WordApplicationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}