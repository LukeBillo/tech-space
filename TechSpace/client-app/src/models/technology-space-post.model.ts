import { FeedProvider } from "./feed-provider.enum";

export type TechnologySpacePost = {
    author: string;
    title: string;
    content: string;
    urlLink: string;
    source: FeedProvider
}