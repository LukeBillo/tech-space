using System;
using System.Runtime.Serialization;

namespace TechSpace.Reddit.Exceptions
{
    [Serializable]
    public class RedditGenericUnexpectedKindException : Exception
    {
        public RedditGenericUnexpectedKindException()
        {
        }

        public RedditGenericUnexpectedKindException(string message) : base(message)
        {
        }

        public RedditGenericUnexpectedKindException(string message, Exception inner) : base(message, inner)
        {
        }

        protected RedditGenericUnexpectedKindException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}