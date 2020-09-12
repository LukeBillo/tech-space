using System.Collections.Generic;
using System.Linq;
using TechSpace.Data.Models;

namespace TechSpace.Web.Models
{
    public class Space
    {
        public Space() {}

        public Space(SpaceRow spaceRow, IEnumerable<SpaceFeedRow> spaceFeedRows)
        {
            Identifier = spaceRow.Identifier;
            Name = spaceRow.Name;
            Description = spaceRow.Description;
            Feeds = spaceFeedRows.Select(row => new SpaceFeed(row)).ToList();
        }
        
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<SpaceFeed> Feeds { get; set; }
    }
}