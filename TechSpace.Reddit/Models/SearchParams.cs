using System.Collections.Generic;
using Refit;

namespace TechSpace.Reddit.Models
{
    public class SearchParams
    {
        [AliasAs("id")]
        public string Id36 { get; set; }
        
        public IEnumerable<string> SubredditNames { get; set; }

        [AliasAs("sr_name")]
        public string CommaSeparatedSubreddits => SubredditNames != null ? string.Join(',', SubredditNames) : null;
        
        [AliasAs("url")]
        public string Url { get; set; }
    }
}