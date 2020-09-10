import { AxiosInstance } from "axios";
import { AxiosClient } from "./axios.client";
import { TechnologySpacePost } from "../models/technology-space-post.model";

export class TechSpacesPostsService {
    constructor(private readonly axiosClient: AxiosInstance) {}

    async get(spaceName: string) {
        const response = await this.axiosClient.get<Array<TechnologySpacePost>>(`spaces/${spaceName}/posts`);
        return response.data; 
    }

    async getPopular() {
        return await this.get('popular');
    }
}

export const TechSpacesPostsClient = new TechSpacesPostsService(AxiosClient);