using System.Text.RegularExpressions;

namespace Common.Domain.Utilities
{

    public static class TextHelper
    {
        public static bool IsUniCode(this string value)
        {
            return value.Any(c => c > 255);
        }

        public static string Subscribe(this string text, int length)
        {
            if (string.IsNullOrEmpty(text) || text.Length <= length)
            {
                return text;
            }
            return text.Substring(0, length - 3) + "...";
        }

        public static string ToSlug(this string url)
        {
            
            return url.Trim().ToLower()
                .Replace("%", "")
                .Replace("+", "")
                .Replace("?", "")
                .Replace("^", "")
                .Replace("*", "")
                .Replace("@", "")
                .Replace("|", "")
                .Replace("#", "")
                .Replace("~", "")
                .Replace("(", "")
                .Replace("=", "")
                .Replace(")", "")
                .Replace("/", "")
                .Replace(@"\", "")
                .Replace("..", "")
                .Replace(" ", "-");
        }

        public static bool IsText(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            var isNumber = Regex.IsMatch(value, @"^\d+$");
            return !isNumber;
        }

        public static string SetUnReadableEmail(this string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                return email;
            }

            var parts = email.Split('@');
            var localPart = parts[0];

            if (localPart.Length <= 9)
            {
                return "..." + localPart;
            }

            return "..." + localPart.Substring(9);
        }
    }
}
