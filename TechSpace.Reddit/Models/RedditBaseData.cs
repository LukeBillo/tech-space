using System;
using Newtonsoft.Json;

namespace TechSpace.Reddit.Models
{
    [Serializable]
    public class RedditBaseData
    {
        [JsonProperty("modhash")]
        public string Modhash { get; set; }
        
        [JsonProperty("dist")]
        public int? Dist { get; set; }
        
        [JsonProperty("after")]
        public string After { get; set; }
        
        [JsonProperty("before")]
        public string Before { get; set; }
    }
}