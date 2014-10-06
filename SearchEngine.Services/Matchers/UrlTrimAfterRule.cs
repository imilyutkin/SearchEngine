using System;

namespace SearchEngine.Services.Matchers
{
    public class UrlTrimAfterRule : ITrimRule
    {
        protected String TrimAfter;

        public UrlTrimAfterRule(String trimAfter)
        {
            TrimAfter = trimAfter;
        }

        public string TrimUrl(String url)
        {
            var trimAfterIndex = url.IndexOf(TrimAfter, StringComparison.InvariantCulture);
            return trimAfterIndex == -1 ? url : url.Substring(0, trimAfterIndex);
        }
    }
}
