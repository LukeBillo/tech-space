import { FeedProvider } from "./feed-provider.enum";
import { PostFilter } from './post-filter.enum'

export type TechnologySpacePost = {
    id: string;
    author: string;
    title: string;
    content: string;
    passthroughUrl: string;
    provider: FeedProvider;
    filter: PostFilter;
}

export const GenerateUniqueKeyForPost = (post: TechnologySpacePost) =>  GenerateUniqueKeyForProviderAndPostId(post.provider, post.id);

export const GenerateUniqueKeyForProviderAndPostId = (provider: FeedProvider, postId: string) => `${provider}-${postId}`;