
namespace WordLab.Domain.Entity
{
    public class ClassifiedWord
    {
        public PhoneticSimilarity PhoneticsSimilarities { get; set; } = new();
        public Context Contexts { get; set; } = new();
        public GrammaticalType GrammaticalsTypes { get; set; } = new();
    }
}