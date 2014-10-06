using System;

namespace SearchEngine.Services.Matchers
{
    public class UrlStartsWithMatchRule : IMatchRule
    {
        protected String StartsWithString;

        public UrlStartsWithMatchRule(String startsWithString)
        {
            StartsWithString = startsWithString;
        }

        public bool IsMatchUrl(String url)
        {
            return url.StartsWith(StartsWithString);
        }
    }
}
