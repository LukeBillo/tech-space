using System.Threading.Tasks;
using SqlKata.Execution;
using TechSpace.Data.Models;

namespace TechSpace.Data
{
    public interface ITechSpaceRepository
    {
        Task<Space> Get(string identifier);
    }

    public class TechSpaceRepository : ITechSpaceRepository
    {
        private const string SpacesTable = "Space";
        private readonly ITechSpaceQueryFactoryManager _queryFactoryManager;

        public TechSpaceRepository(ITechSpaceQueryFactoryManager queryFactoryManager)
        {
            _queryFactoryManager = queryFactoryManager;
        }
        
        public async Task<Space> Get(string identifier)
        {
            using var database = _queryFactoryManager.CreateQueryFactory();
            return await database.Query(SpacesTable)
                .Where("identifier", identifier)
                .FirstAsync<Space>();
        }
    }
}