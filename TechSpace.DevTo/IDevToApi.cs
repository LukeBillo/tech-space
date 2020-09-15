using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using TechSpace.DevTo.Models;

namespace TechSpace.DevTo
{
    public interface IDevToApi
    {
        [Get("/articles")]
        Task<List<DevToArticle>> GetArticles([Query] GetArticleQueryParams queryParams = null);
    }
}