import Axios from "axios";

export const AxiosClient = Axios.create({
    baseURL: 'https://localhost:5001',
    responseType: 'json',
    headers: {
        'Content-Type': 'application/json'
    }
});