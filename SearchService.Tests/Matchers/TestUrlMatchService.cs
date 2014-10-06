using System.Security.Cryptography.X509Certificates;
using SearchEngine.Services.Impl;
using SearchEngine.Services.Matchers;
using Xunit;

namespace SearchService.Tests.Matchers
{
    public class TestUrlMatchService
    {
        [Fact]
        public void UrlMatchService_NullParams()
        {
            var matcher = new UrlMatchService(null, null);
            var url = "http://habrahabr.ru/post/12345#comments";
            Assert.Equal(url, matcher.GetMatchedUrl(url));
        }

        [Fact]
        public void UrlMatchService_NotMatch()
        {
            var url = "http://habrahabr.ru/post/12345#comments";
            var urlStartsWith = "http://habrahabr.ru/company";
            var matcher = new UrlMatchService(new IMatchRule[]{new UrlStartsWithMatchRule(urlStartsWith) }, null);
            Assert.Throws<UrlNotMatchException>(() => matcher.GetMatchedUrl(url));
        }

        [Fact]
        public void UrlMatchService_OneMatchAndTrim()
        {
            var url = "http://habrahabr.ru/post/12345#comments";
            var resultUrl = "http://habrahabr.ru/post/12345";
            var urlStartsWith = "http://habrahabr.ru/post";
            var trimAfter = "#";
            var matcher = new UrlMatchService(new IMatchRule[] {new UrlStartsWithMatchRule(urlStartsWith)},
                new ITrimRule[] {new UrlTrimAfterRule(trimAfter)});
            Assert.Equal(resultUrl, matcher.GetMatchedUrl(url));
        }

        [Fact]
        public void UrlMatchService_TwoMatchAndOneTrim()
        {
            var url = "http://habrahabr.ru/post/12345#comments";
            var resultUrl = "http://habrahabr.ru/post/12345";
            var urlStartsWith1 = "http://habrahabr.ru/post";
            var urlStartsWith2 = "http://habrahabr.ru/company";
            var trimAfter = "#";
            var matcher =
                new UrlMatchService(
                    new IMatchRule[]
                    {new UrlStartsWithMatchRule(urlStartsWith1), new UrlStartsWithMatchRule(urlStartsWith2)},
                    new ITrimRule[] {new UrlTrimAfterRule(trimAfter)});
            Assert.Equal(resultUrl, matcher.GetMatchedUrl(url));
        }
    }
}
