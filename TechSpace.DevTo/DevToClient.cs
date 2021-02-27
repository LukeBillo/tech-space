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
        Task<Article> GetArticleById(string id);
    }
    
    public class DevToClient : IDevToClient
    {
        private readonly IDevToApi _devToApi;

        public DevToClient(HttpClient devToHttpClient)
        {
            _devToApi = RestService.For<IDevToApi>(devToHttpClient);
        }

        public Task<List<Article>> GetArticles(GetArticleQueryParams queryParams = null) => _devToApi.GetArticles(queryParams);

        public async Task<Article> GetArticleById(string id) => (await _devToApi.GetArticleById(id)).ToArticle() ;
    }
}