using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TechSpace.Web.Models
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