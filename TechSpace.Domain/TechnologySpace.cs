﻿using System;
using System.Collections.Generic;

namespace TechSpace.Domain
{
    public class TechnologySpace
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TechnologySpaceFeed> Feeds { get; set; }
    }
}