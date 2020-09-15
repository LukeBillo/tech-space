import { AxiosInstance } from "axios";
import { AxiosClient } from "./axios.client";
import { TechnologySpacePost } from "../models/technology-space-post.model";

export class TechSpacesPostsHttpClient {
    constructor(private readonly axiosClient: AxiosInstance) {}

    async get(spaceName: string) {
        const response = await this.axiosClient.get<Array<TechnologySpacePost>>(`spaces/${spaceName}/posts`);
        return response.data; 
    }

    async getPopular() {
        return await this.get('popular');
    }
}

export const TechSpacesPostsClient = new TechSpacesPostsHttpClient(AxiosClient);