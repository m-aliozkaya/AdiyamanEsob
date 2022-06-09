
using System.Text.RegularExpressions;
using System;

namespace Core.Utilities.Extensions;

public static class StringExtensions
{
    public static string ShortText(this string text, int length = 250)
    {
        return string.IsNullOrEmpty(text) ? string.Empty : string.Concat(text.AsSpan(0, Math.Min(text.Length, length)), "...");
    }
    
    public static string StripTags(this string text)
    {
        return Regex.Replace(text, "<.*?>|&.*?;", string.Empty);
    }
}