import { FeedProvider } from "./feed-provider.enum";
import { PostFilter } from './post-filter.enum'

export type TechnologySpacePost = {
    id: string;
    author: string;
    title: string;
    content: string;
    urlLink: string;
    source: FeedProvider;
    filter: PostFilter;
}

export const GetUniquePostId = (post: TechnologySpacePost) => {
    return `${post.source}-${post.id}`;
}