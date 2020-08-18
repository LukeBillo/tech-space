using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TechSpace.Reddit.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Kind
    {
        [EnumMember(Value = "Listing")]
        Listing,
        
        [EnumMember(Value = "t1")]
        Comment,
        
        [EnumMember(Value = "t2")]
        Account,
        
        [EnumMember(Value = "t3")]
        Link,
        
        [EnumMember(Value = "t4")]
        Message,
        
        [EnumMember(Value = "t5")]
        SubReddit,

        [EnumMember(Value = "t6")]
        Award
    }
}