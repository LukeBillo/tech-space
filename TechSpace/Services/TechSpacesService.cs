using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechSpace.Domain;

namespace TechSpace.Services
{
    public interface ITechSpacesService
    {
        Task<IList<TechnologySpace>> GetAll();
    }

    public class TechSpacesService : ITechSpacesService
    {
        public async Task<IList<TechnologySpace>> GetAll()
        {
            return new List<TechnologySpace>
            {
                new TechnologySpace
                {
                    Id = Guid.NewGuid(),
                    Name = "C#",
                    Feeds = new List<TechnologySpaceFeed>
                    {
                        new TechnologySpaceFeed
                        {
                            Provider = FeedProvider.Reddit,
                            Connection = new FeedConnection
                            {
                                Name = "dotnet",
                                Resource = "dotnet"
                            }
                        },
                        new TechnologySpaceFeed
                        {
                            Provider = FeedProvider.Reddit,
                            Connection = new FeedConnection
                            {
                                Name = "csharp",
                                Resource = "csharp"
                            }
                        }
                    }
                }
            };
        }
    }
}