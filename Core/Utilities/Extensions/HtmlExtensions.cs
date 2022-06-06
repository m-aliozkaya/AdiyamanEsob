using System.Text.RegularExpressions;
using static System.String;

namespace Core.Utilities.Extensions;

public static class HtmlExtensions
{
    public static string StripTags(this string text)
    {
        return Regex.Replace(text, "<.*?>|&.*?;", Empty);
    }
}