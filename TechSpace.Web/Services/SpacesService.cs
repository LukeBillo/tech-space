using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechSpace.Domain;

namespace TechSpace.Services
{
    public interface ITechSpacesService
    {
        Task<IList<Space>> GetAll();
        Task<Space> Get(string name);
    }

    public class SpacesService : ITechSpacesService
    {
        public async Task<IList<Space>> GetAll()
        {
            return new List<Space>
            {
                new Space
                {
                    Identifier = "csharp",
                    Name = "C#",
                    Description = "Everything C# and .NET related",
                    Feeds = new List<SpaceFeed>
                    {
                        new SpaceFeed
                        {
                            Provider = FeedProvider.Reddit,
                            Connection = new FeedConnection
                            {
                                Name = ".NET",
                                Resource = "dotnet"
                            }
                        },
                        new SpaceFeed
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
                new Space
                {
                    Identifier = "javaScript",
                    Name = "JavaScript",
                    Description = "All things JavaScript",
                    Feeds = new List<SpaceFeed>
                    {
                        new SpaceFeed
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

        public async Task<Space> Get(string name)
        {
            var allSpaces = await GetAll();
            return allSpaces.FirstOrDefault(space => space.Name == name);
        }
    }
}