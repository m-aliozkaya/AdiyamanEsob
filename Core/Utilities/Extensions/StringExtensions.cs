namespace Core.Utilities.Extensions;

public static class StringExtensions
{
    public static string ShortText(this string text, int length = 150)
    {
        return text.Substring(0, Math.Min(text.Length, length)) + "...";
    }
}