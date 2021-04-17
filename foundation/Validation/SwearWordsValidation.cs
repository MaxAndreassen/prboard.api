using System.Linq;

namespace foundation.Validation
{
    public static class SwearWordsValidation
    {
        public static bool IsGoodLanguage(string text)
        {
            if (string.IsNullOrEmpty(text))
                return true;

            var words = text
                .Split(' ')
                .Select(w => w.ToUpper());

            return !SwearWords.Words.Any(word => words.Contains(word));
        }
    }
}
