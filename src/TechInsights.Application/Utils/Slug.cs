using System;
using System.Collections.Generic;

namespace TechInsights.Application.Utils
{
    public static class Slug
    {
        private static readonly List<string> _ReservedCharacters = new List<string> { "!", "#", "$", "&", "'", "(", ")", "*", ",", "/", ":", ";", "=", "?", "@", "[", "]", "\"", "%", ".", "<", ">", "\\", "^", "_", "'", "{", "}", "|", "~", "`", "+" };

        public static string CreateSlug(string title)
        {
            title = title?.ToLowerInvariant().Replace(Constants.Space, Constants.Dash, StringComparison.OrdinalIgnoreCase) ?? string.Empty;
            title = RemoveReservedUrlCharacters(title);

            return title.ToLowerInvariant();
        }

        private static string RemoveReservedUrlCharacters(string text)
        {
            foreach (var chr in _ReservedCharacters)
            {
                text = text.Replace(chr, string.Empty, StringComparison.OrdinalIgnoreCase);
            }

            return text;
        }
    }
}
