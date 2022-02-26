using HackerNewsService;
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class HackerNewsApi:IHackerNewsApi
{
	public readonly string _targetNews;
	public readonly string _targetStories;
	public HackerNewsApi(string targetNews,string targetStories)
	{
		_targetNews = targetNews;
		_targetStories = targetStories;
	}
	public async Task<string> CallHackerNewsApi(string filtro)
	{
		return await GenericCall(_targetNews+filtro);
	}
	public async Task<string> ReturnTwentyBestStories()
	{
		return await GenericCall(_targetStories);
	}
	private async Task<string> GenericCall(string uri)
	{
		using (var client = new HttpClient())
		{
			var response = await client.GetAsync(uri);
			if (response.StatusCode == System.Net.HttpStatusCode.OK)
			{
				var content = response.Content;
				var json = await content.ReadAsStringAsync();
				return json;
			}
			else
			{
				throw new Exception($"The call was not succeded check the error code: {response.StatusCode}");
			}
		}
	}
}
