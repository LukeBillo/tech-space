import { FeedProvider } from "./feed-provider.enum";
import { PostFilter } from './post-filter.enum'

export type TechnologySpacePost = {
    author: string;
    title: string;
    content: string;
    urlLink: string;
    source: FeedProvider;
    filter: PostFilter;
}