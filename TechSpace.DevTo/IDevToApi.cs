using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using TechSpace.DevTo.Models;

namespace TechSpace.DevTo
{
    public interface IDevToApi
    {
        [Get("/articles")]
        Task<List<Article>> GetArticles([Query] GetArticleQueryParams queryParams = null);

        [Get("/articles/{id}")]
        Task<ArticleById> GetArticleById(string id);
    }
}