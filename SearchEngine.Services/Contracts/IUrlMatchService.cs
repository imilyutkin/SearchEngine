using System;

namespace SearchEngine.Services.Contracts
{
    public interface IUrlMatchService
    {
        String GetMatchedUrl(String url);
    }
}
