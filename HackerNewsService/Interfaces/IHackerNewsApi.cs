using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerNewsService
{
    public interface IHackerNewsApi
    {
        Task<string> CallHackerNewsApi(string filtro);
        Task<string> ReturnTwentyBestStories();
    }
}
