import { AxiosInstance } from "axios";
import { AxiosClient } from "./axios.http";
import { TechnologySpacePost } from "../models/technology-space-post.model";
import { FeedProvider } from "../models/feed-provider.enum";

export class TechSpacesPostsHttpClient {
    constructor(private readonly axiosClient: AxiosInstance) {}

    async getAllForSpace(spaceName: string) {
        const response = await this.axiosClient.get<Array<TechnologySpacePost>>(`spaces/${spaceName}/posts`);
        console.log(response.data);
        return response.data; 
    }

    async getById(provider: FeedProvider, postId: string) {
        const response = await this.axiosClient.get<TechnologySpacePost>(`posts/${provider}/${postId}`);
        return response.data;
    }

    async getPopular() {
        return await this.getAllForSpace('popular');
    }
}

export const TechSpacesPostsClient = new TechSpacesPostsHttpClient(AxiosClient);