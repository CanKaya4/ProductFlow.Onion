using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Domain.Helper
{
    public static class StringExtensions
    {
        public static string ToSlug(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            text = text.ToLowerInvariant();

            var replacements = new Dictionary<char, char>
            {
                {'ğ', 'g'}, {'ü', 'u'}, {'ş', 's'}, {'ı', 'i'}, {'ö', 'o'}, {'ç', 'c'}
            };

            foreach (var pair in replacements)
                text = text.Replace(pair.Key, pair.Value);

            text = System.Text.RegularExpressions.Regex.Replace(text, @"[^a-z0-9\s-]", "");

            text = System.Text.RegularExpressions.Regex.Replace(text, @"\s+", "-").Trim();
            text = System.Text.RegularExpressions.Regex.Replace(text, @"-+", "-");


            return text;
        }
    }
}
