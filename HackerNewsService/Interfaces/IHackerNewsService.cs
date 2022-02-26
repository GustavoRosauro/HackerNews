using HackerNewsContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNewsService.Interface
{
    public interface IHackerNewsService
    {
        Task<List<StoriesContract>> ReturnTwentyStories();
    }
}
