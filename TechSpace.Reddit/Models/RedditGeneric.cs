using Newtonsoft.Json.Linq;
using TechSpace.Reddit.Exceptions;

namespace TechSpace.Reddit.Models
{
    public class RedditGeneric
    {
        public Kind Kind { get; set; }
        public JObject Data { get; set; }

        public Listing ToListing()
        {
            if (Kind != Kind.Listing)
                throw new RedditGenericUnexpectedKindException();

            return Data.ToObject<Listing>();
        }

        public Post ToPost()
        {
            if (Kind != Kind.Link)
                throw new RedditGenericUnexpectedKindException();

            return Data.ToObject<Post>();
        }
    }
}