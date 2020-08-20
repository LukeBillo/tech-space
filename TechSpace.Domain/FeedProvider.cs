using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TechSpace.Domain
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedProvider
    {
        [EnumMember(Value = "Reddit")]
        Reddit,
        
        [EnumMember(Value = "Dev.to")]
        DevTo
    }
}