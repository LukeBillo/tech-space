import {AxiosInstance} from "axios";
import { TechnologySpace } from "../shared/models/technology-space.model";
import { AxiosClient } from "./axios.client";

export class TechSpacesHttpClient {
    constructor(private readonly axiosClient: AxiosInstance) {}

    async getAll(): Promise<Array<TechnologySpace>> {
        const response = await this.axiosClient.get<Array<TechnologySpace>>('spaces/all');
        return response.data;
    }

    async get(name: string): Promise<TechnologySpace> {
        const response = await this.axiosClient.get<TechnologySpace>(`spaces/${name}`);
        return response.data;
    }
}

export const TechSpacesClient = new TechSpacesHttpClient(AxiosClient);
