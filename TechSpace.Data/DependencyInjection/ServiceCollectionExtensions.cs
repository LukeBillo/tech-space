using Microsoft.Extensions.DependencyInjection;

namespace TechSpace.Data.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTechSpaceRepositories(this IServiceCollection serviceCollection, string techSpaceConnectionString)
        {
            serviceCollection.Configure<TechSpaceDatabaseOptions>(options =>
            {
                options.ConnectionString = techSpaceConnectionString;
            });
            
            serviceCollection.AddSingleton<ITechSpaceQueryFactoryManager, TechSpaceQueryFactoryManager>();
            serviceCollection.AddSingleton<ITechSpaceRepository, TechSpaceRepository>();
            serviceCollection.AddSingleton<ITechSpaceFeedRepository, TechSpaceFeedRepository>();

            return serviceCollection;
        }
    }
}