using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using TechSpace.DevTo.Models;

namespace TechSpace.DevTo
{
    public interface IDevToClient
    {
        Task<List<Article>> GetArticles(GetArticleQueryParams queryParams = null);
    }
    
    public class DevToClient : IDevToClient
    {
        private readonly IDevToApi _devToApi;

        public DevToClient(HttpClient devToHttpClient)
        {
            _devToApi = RestService.For<IDevToApi>(devToHttpClient);
        }

        public async Task<List<Article>> GetArticles(GetArticleQueryParams queryParams = null) => await _devToApi.GetArticles(queryParams);
    }
}