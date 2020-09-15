using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechSpace.Data;
using TechSpace.Data.Models;
using TechSpace.Web.Models;

namespace TechSpace.Web.Services
{
    public interface ITechSpacesService
    {
        Task<IList<Space>> GetAll();
        Task<Space> Get(string id);
    }

    public class SpacesService : ITechSpacesService
    {
        private readonly ITechSpaceRepository _techSpaceRepository;
        private readonly ITechSpaceFeedRepository _techSpaceFeedRepository;

        public SpacesService(ITechSpaceRepository techSpaceRepository, ITechSpaceFeedRepository techSpaceFeedRepository)
        {
            _techSpaceRepository = techSpaceRepository;
            _techSpaceFeedRepository = techSpaceFeedRepository;
        }

        public async Task<IList<Space>> GetAll()
        {
            var spaceRows = await _techSpaceRepository.GetAll();
            var spaces = spaceRows
                .Select(async spaceRow =>
                {
                    var spaceFeedRows = await _techSpaceFeedRepository.Get(spaceRow.Identifier);
                    return new Space(spaceRow, spaceFeedRows);
                });

            return await Task.WhenAll(spaces);
        }

        public async Task<Space> Get(string id)
        {
            var spaceRow = await _techSpaceRepository.GetById(id);
            var spaceFeedRows = await _techSpaceFeedRepository.Get(spaceRow.Identifier);
            return new Space(spaceRow, spaceFeedRows);
        }
    }
}