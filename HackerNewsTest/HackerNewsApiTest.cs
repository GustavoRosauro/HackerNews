using System;
using HackerNewsService;
using Xunit;

namespace HackerNewsTest
{
    public class HackerNewsApiTest
    {
        public readonly string _targetNews;
        public readonly string _targetStory;
        public HackerNewsApiTest()
        {
            _targetNews = "https://hacker-news.firebaseio.com/v0/item/";
            _targetStory = "https://hacker-news.firebaseio.com/v0/beststories.json";
        }
        [Fact]
        public void CallHackerApiNewsTest()
        {
            var hackerNews = new HackerNewsApi(_targetNews,"");
            var json = hackerNews.CallHackerNewsApi("8863.json?print=pretty").Result;
            Assert.NotEqual("",json);
        }
        [Fact]
        public void CallHackerApiStoryTest()
        {
            var hackerNews = new HackerNewsApi("",_targetStory);
            var json = hackerNews.ReturnTwentyBestStories().Result;
            Assert.NotEqual("", json);
        }
        [Fact]
        public void ReturnTwentyStoriesTest()
        {
            IHackerNewsApi hackerNewsApi = new HackerNewsApi(_targetNews,_targetStory);
            var service = new HackerNewsService.HackerNewsService(hackerNewsApi);
            var list = service.ReturnTwentyStories().Result;
            Assert.Equal(20,list.Count);
        }
    }
}
