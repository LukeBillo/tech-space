using System;
using System.Collections.Generic;

namespace TechSpace.Domain
{
    public class Space
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SpaceFeed> Feeds { get; set; }
    }
}