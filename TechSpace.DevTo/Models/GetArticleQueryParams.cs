using System.Runtime.Serialization;
using Refit;

namespace TechSpace.DevTo.Models
{
    public class GetArticleQueryParams
    {
        [AliasAs("page")]
        public int Page { get; set; }
        
        [AliasAs("per_page")]
        public int ArticlesPerPage { get; set; }
        
        [AliasAs("tag")]
        public string Tag { get; set; }
        
        [AliasAs("username")]
        public string Username { get; set; }
        
        [AliasAs("state")]
        public ArticleState State { get; set; }
        
        [AliasAs("top")]
        public int Top { get; set; }
        
        [AliasAs("collection_id")]
        public int CollectionId { get; set; }
    }

    public enum ArticleState
    {
        [EnumMember(Value = "fresh")]
        Fresh,
        
        [EnumMember(Value = "rising")]
        Rising,
        
        [EnumMember(Value = "all")]
        All
    }
}