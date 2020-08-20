using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechSpace.Domain;

namespace TechSpace.Services
{
    public interface ITechSpacesService
    {
        Task<IList<TechnologySpace>> GetAll();
        Task<TechnologySpace> Get(string name);
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
                    Description = "Everything C# and .NET related",
                    Feeds = new List<TechnologySpaceFeed>
                    {
                        new TechnologySpaceFeed
                        {
                            Provider = FeedProvider.Reddit,
                            Connection = new FeedConnection
                            {
                                Name = ".NET",
                                Resource = "dotnet"
                            }
                        },
                        new TechnologySpaceFeed
                        {
                            Provider = FeedProvider.Reddit,
                            Connection = new FeedConnection
                            {
                                Name = "C#",
                                Resource = "csharp"
                            }
                        }
                    }
                },
                new TechnologySpace
                {
                    Id = Guid.NewGuid(),
                    Name = "JavaScript",
                    Description = "All things JavaScript",
                    Feeds = new List<TechnologySpaceFeed>
                    {
                        new TechnologySpaceFeed
                        {
                            Provider = FeedProvider.Reddit,
                            Connection = new FeedConnection
                            {
                                Name = "Javascript",
                                Resource = "javascript"
                            }
                        }
                    }
                }
            };
        }

        public async Task<TechnologySpace> Get(string name)
        {
            var allSpaces = await GetAll();
            return allSpaces.FirstOrDefault(space => space.Name == name);
        }
    }
}