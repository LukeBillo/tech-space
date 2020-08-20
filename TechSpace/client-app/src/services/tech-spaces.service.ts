import Axios, {AxiosInstance} from "axios";
import {TechnologySpace} from "../models/technology-space.model";

export class TechSpacesService {
    private readonly axiosClient: AxiosInstance;
    
    constructor() {
        this.axiosClient = Axios.create({
            baseURL: 'https://localhost:5001/api/spaces',
            responseType: 'json',
            headers: {
                'Content-Type': 'application/json'
            }
        });
    }

    async getAll(): Promise<Array<TechnologySpace>> {
        const response = await this.axiosClient.get<Array<TechnologySpace>>('all');
        if (response.status !== 200) {
            console.error(`Error from TechSpacesService.getAll(). Received HTTP status ${response.status}: ${response.statusText}`);
        }
        
        return response.data;
    }

    async get(name: string): Promise<TechnologySpace> {
        const response = await this.axiosClient.get<TechnologySpace>(name);
        if (response.status !== 200) {
            console.error(`Error from TechSpacesService.get(${name}). Received HTTP status ${response.status}: ${response.statusText}`);
        }

        return response.data;
    }
}

export const TechSpacesClient = new TechSpacesService();

