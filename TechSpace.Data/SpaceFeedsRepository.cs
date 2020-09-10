using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlKata.Execution;
using TechSpace.Data.Models;

namespace TechSpace.Data
{
    public interface ISpaceFeedsRepository
    {
        Task<IList<Feed>> Get(string spaceIdentifier);
    }

    public class SpaceFeedsRepository : ISpaceFeedsRepository
    {
        private const string FeedsTable = "SpaceFeed";
        private readonly ITechSpaceQueryFactoryManager _queryFactoryManager;

        public SpaceFeedsRepository(ITechSpaceQueryFactoryManager queryFactoryManager)
        {
            _queryFactoryManager = queryFactoryManager;
        }
        
        public async Task<IList<Feed>> Get(string spaceIdentifier)
        {
            using var database = _queryFactoryManager.CreateQueryFactory();
            var feeds= await database.Query(FeedsTable)
                .Where("SpaceIdentifier", spaceIdentifier)
                .GetAsync<Feed>();

            return feeds.ToList();
        }
    }
}