using System.Text.RegularExpressions;

namespace Core.Utilities.Extensions;

public static class StringExtensions
{
    public static string ShortText(this string text, int length = 250)
    {
        return text.Substring(0, Math.Min(text.Length, length)) + "...";
    }
    
    public static string StripTags(this string text)
    {
        return Regex.Replace(text, "<.*?>|&.*?;", string.Empty);
    }
}