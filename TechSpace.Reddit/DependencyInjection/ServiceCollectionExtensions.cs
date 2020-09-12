using System;
using Microsoft.Extensions.DependencyInjection;

namespace TechSpace.Reddit.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddReddit(this IServiceCollection serviceCollection, RedditOptions redditOptions)
        {
            serviceCollection.AddHttpClient<IRedditClient, RedditClient>(client =>
            {
                client.BaseAddress = new Uri(redditOptions.BaseUrl);
            });
            
            return serviceCollection;
        }
    }
}