using System;

namespace SearchEngine.Services.Matchers
{
    public interface IMatchRule
    {
        bool IsMatchUrl(String url);
    }
}
