using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlKata.Execution;
using TechSpace.Data.Models;

namespace TechSpace.Data
{
    public interface ITechSpaceFeedRepository
    {
        Task<IList<SpaceFeedRow>> Get(string spaceIdentifier);
    }

    public class TechSpaceFeedRepository : ITechSpaceFeedRepository
    {
        private const string FeedsTable = "SpaceFeed";
        private readonly ITechSpaceQueryFactoryManager _queryFactoryManager;

        public TechSpaceFeedRepository(ITechSpaceQueryFactoryManager queryFactoryManager)
        {
            _queryFactoryManager = queryFactoryManager;
        }
        
        public async Task<IList<SpaceFeedRow>> Get(string spaceIdentifier)
        {
            using var database = _queryFactoryManager.CreateQueryFactory();
            var feedsForSpace = await database.Query(FeedsTable)
                .Where("SpaceIdentifier", spaceIdentifier)
                .GetAsync<SpaceFeedRow>();

            return feedsForSpace.ToList();
        }
    }
}