using System;
using SearchEngine.Services.Matchers;
using Xunit;

namespace SearchService.Tests.Matchers
{
    public class TestMatchers
    {
        [Fact]
        public void UrlStartWithMatchSimple_IsMatch()
        {
            var url = "http://habrahabr.ru/post/121545";
            var startsWith = "http://habrahabr.ru/post/";
            var rule = new UrlStartsWithMatchRule(startsWith);
            Assert.True(rule.IsMatchUrl(url));
        }

        [Fact]
        public void UrlStartWithMatchSimple_IsNotMatch()
        {
            var url = "http://habrahabr.ru/post/121545";
            var startsWith = "http://habrahabr.ru/company/";
            var rule = new UrlStartsWithMatchRule(startsWith);
            Assert.False(rule.IsMatchUrl(url));
        }

        [Fact]
        public void UrlStartWithMatchSameUrl_IsMatch()
        {
            var url = "http://habrahabr.ru/post/121545";
            var rule = new UrlStartsWithMatchRule(url);
            Assert.True(rule.IsMatchUrl(url));
        }

        [Fact]
        public void UrlTrimAfterRule_TrimAfterCharacter()
        {
            var url = "http://habrahabr.ru/post/121545#comments";
            var resultUrl = "http://habrahabr.ru/post/121545";
            var rule = new UrlTrimAfterRule("#");
            Assert.Equal(resultUrl, rule.TrimUrl(url));
        }

        [Fact]
        public void UrlTrimAfterRule_TrimAfterSubstring()
        {
            var url = "http://habrahabr.ru/post/121545#comments";
            var resultUrl = "http://habrahabr.ru/post/121545";
            var rule = new UrlTrimAfterRule("#comm");
            Assert.Equal(resultUrl, rule.TrimUrl(url));
        }

        [Fact]
        public void UrlTrimAfterRule_TrimAfterTrimmedSubstring()
        {
            var url = "http://habrahabr.ru/post/121545#comments";
            var resultUrl = "http://habrahabr.ru/post/121545";
            var rule = new UrlTrimAfterRule("#comments");
            Assert.Equal(resultUrl, rule.TrimUrl(url));
        }

        [Fact]
        public void UrlTrimAfterRule_TrimWithDuplicateCharacter()
        {
            var url = "http://habrahabr.ru/post/121545#comments#hi";
            var resultUrl = "http://habrahabr.ru/post/121545";
            var rule = new UrlTrimAfterRule("#");
            Assert.Equal(resultUrl, rule.TrimUrl(url));
        }
    }
}
