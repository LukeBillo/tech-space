import { FeedProvider } from "./feed-provider.enum";
import { PostFilter } from './post-filter.enum'

export type TechnologySpacePost = {
    id: string;
    spaceId: string;
    author: string;
    title: string;
    content: string;
    urlLink: string;
    source: FeedProvider;
    filter: PostFilter;
}

export const GenerateUniqueKeyForPost = (post: TechnologySpacePost) => `${post.source}-${post.id}`;