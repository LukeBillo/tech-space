using System.Runtime.Serialization;

namespace TechSpace.Reddit.Models
{
    public enum PostFilter
    {
        [EnumMember(Value = "hot")]
        Hot,
        
        [EnumMember(Value = "new")]
        New,
        
        [EnumMember(Value = "random")]
        Random,
        
        [EnumMember(Value = "rising")]
        Rising,
        
        [EnumMember(Value = "top")]
        Top,
        
        [EnumMember(Value = "controversial")]
        Controversial
    }
}