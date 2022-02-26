using HackerNewsContract;
using HackerNewsService.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNewsService
{
    public class HackerNewsService: IHackerNewsService
    {
        private readonly IHackerNewsApi _hackerNewsApi;
        public HackerNewsService(IHackerNewsApi hackerNewsApi)
        {
            _hackerNewsApi = hackerNewsApi;
        }
        public async Task<List<StoriesContract>> ReturnTwentyStories()
        {            
            var listStories = new List<StoriesContract>();
            int[] ids = JsonConvert.DeserializeObject<int[]>(await _hackerNewsApi.ReturnTwentyBestStories());
            var idsList = ids.Select(x => x.ToString()+ ".json?print=pretty").Take(20);
            foreach (var id in idsList)
            {

                var storiesDto = JsonConvert.DeserializeObject<StoriesDTO>(await _hackerNewsApi.CallHackerNewsApi(id));
                var storiesContract = new StoriesContract()
                {
                    Title = storiesDto.Title,
                    CommentCount = storiesDto.Descendants,
                    PostedBy = storiesDto.By,
                    Score = storiesDto.Score,
                    Time = new DateTime(1970,01,01).AddSeconds(storiesDto.Time),
                    Uri = storiesDto.Url
                };
                listStories.Add(storiesContract);
            }
            return listStories;
        }
    }
}
