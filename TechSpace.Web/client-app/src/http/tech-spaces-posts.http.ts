import { AxiosInstance } from "axios";
import { AxiosClient } from "./axios.http";
import { TechnologySpacePost } from "../models/technology-space-post.model";

export class TechSpacesPostsHttpClient {
    constructor(private readonly axiosClient: AxiosInstance) {}

    async getAllForSpace(spaceName: string) {
        const response = await this.axiosClient.get<Array<TechnologySpacePost>>(`spaces/${spaceName}/posts`);
        return response.data; 
    }

    async getById(provider: string, postId: string) {
        const response = await this.axiosClient.get<TechnologySpacePost>(`${provider}/posts/${postId}`);
        return response.data;
    }

    async getPopular() {
        return await this.getAllForSpace('popular');
    }
}

export const TechSpacesPostsClient = new TechSpacesPostsHttpClient(AxiosClient);