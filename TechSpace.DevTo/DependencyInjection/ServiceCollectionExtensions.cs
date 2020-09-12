using System;
using Microsoft.Extensions.DependencyInjection;

namespace TechSpace.DevTo.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        private const string ApiKeyHeader = "api-key";
        
        public static IServiceCollection AddDevTo(this IServiceCollection serviceCollection, DevToOptions devToOptions)
        {
            serviceCollection.AddHttpClient<IDevToClient, DevToClient>(client =>
            {
                client.BaseAddress = new Uri(devToOptions.BaseUrl);
                client.DefaultRequestHeaders.Add(ApiKeyHeader, devToOptions.ApiKey);
            });
            
            return serviceCollection;
        }
    }
}