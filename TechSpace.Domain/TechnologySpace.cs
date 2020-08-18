using System;
using System.Collections.Generic;

namespace TechSpace.Domain
{
    public class TechnologySpace
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<TechnologySpaceFeed> Feeds { get; set; }
    }
}