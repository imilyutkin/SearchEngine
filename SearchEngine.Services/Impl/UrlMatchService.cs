using System;
using System.Data;
using System.Linq;
using SearchEngine.Services.Contracts;
using SearchEngine.Services.Matchers;

namespace SearchEngine.Services.Impl
{
    public class UrlMatchService : IUrlMatchService
    {
        protected IMatchRule[] MatchRules;
        protected ITrimRule[] TrimRules;

        public UrlMatchService(IMatchRule[] matchRules, ITrimRule[] trimRules)
        {
            MatchRules = matchRules;
            TrimRules = trimRules;
        }

        public String GetMatchedUrl(String url)
        {
            if (MatchRules != null)
            {
                var isUrlMatch =
                    MatchRules.Select(rule => rule.IsMatchUrl(url))
                        .Any(isUrlMatchForRule => isUrlMatchForRule == true);
                if (!isUrlMatch)
                    throw new UrlNotMatchException(String.Format("Url {0} not match for rule.", url));
            }
            if (TrimRules != null)
            {
                TrimRules.ToList().ForEach(rule =>
                {
                    url = rule.TrimUrl(url);
                });
            }
            return url;
        }
    }
}
