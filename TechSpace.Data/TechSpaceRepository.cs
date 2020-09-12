using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlKata.Execution;
using TechSpace.Data.Models;

namespace TechSpace.Data
{
    public interface ITechSpaceRepository
    {
        Task<SpaceRow> GetById(string id);
        Task<SpaceRow> GetByName(string name);
        Task<IList<SpaceRow>> GetAll();
    }

    public class TechSpaceRepository : ITechSpaceRepository
    {
        private const string SpacesTable = "Space";
        private readonly ITechSpaceQueryFactoryManager _queryFactoryManager;

        public TechSpaceRepository(ITechSpaceQueryFactoryManager queryFactoryManager)
        {
            _queryFactoryManager = queryFactoryManager;
        }
        
        public async Task<IList<SpaceRow>> GetAll()
        {
            using var database = _queryFactoryManager.CreateQueryFactory();
            var spaces = await database.Query(SpacesTable)
                .GetAsync<SpaceRow>();

            return spaces.ToList();
        }
        
        public async Task<SpaceRow> GetById(string id)
        {
            using var database = _queryFactoryManager.CreateQueryFactory();
            return await database.Query(SpacesTable)
                .Where("identifier", id)
                .FirstAsync<SpaceRow>();
        }
        
        public async Task<SpaceRow> GetByName(string name)
        {
            using var database = _queryFactoryManager.CreateQueryFactory();
            return await database.Query(SpacesTable)
                .Where("name", name)
                .FirstAsync<SpaceRow>();
        }
    }
}