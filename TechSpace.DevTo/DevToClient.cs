using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using TechSpace.DevTo.Models;

namespace TechSpace.DevTo
{
    public interface IDevToClient
    {
        Task<List<DevToArticle>> GetArticles(GetArticleQueryParams queryParams = null);
        Task<DevToArticle> GetArticleById(string id);
    }
    
    public class DevToClient : IDevToClient
    {
        private readonly IDevToApi _devToApi;

        public DevToClient(HttpClient devToHttpClient)
        {
            _devToApi = RestService.For<IDevToApi>(devToHttpClient);
        }

        public Task<List<DevToArticle>> GetArticles(GetArticleQueryParams queryParams = null) => _devToApi.GetArticles(queryParams);

        public Task<DevToArticle> GetArticleById(string id) => _devToApi.GetArticleById(id);
    }
}