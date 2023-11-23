import { environment } from "../environment/environment";
import axios from 'axios';
import { TokenResponse } from "../models/auth/token.response";

const api = axios.create({
    baseURL: environment.apiUrl,
});


api.interceptors.request.use(
    (config) => {
        const storageToken = localStorage.getItem('token');
        const token = storageToken ? JSON.parse(storageToken)?.accessToken : null;
        if (token) {
            config.headers!.Authorization = `Bearer ${token}`;
        }
        return config;
    },
    (error) => Promise.reject(error)
);

api.interceptors.response.use(
    (response) => response,
    async (error) => {
        const originalRequest = error.config;
        console.log("interceptor")
        if (error.response.status === 401 && !originalRequest._retry) {
            originalRequest._retry = true;
            try {
                const storageToken = localStorage.getItem('token');
                const refreshToken = storageToken ? JSON.parse(storageToken)?.refreshToken : null;
                const response = await axios.post<TokenResponse>(environment.apiUrl + '/api/auth/refreshToken', { refreshToken });
                const token = JSON.stringify(response.data);

                localStorage.setItem('token', token);

                originalRequest.headers.Authorization = `Bearer ${token}`;
                return axios(originalRequest);
            } catch (error) {
                console.log(error);
            }
        }

        return Promise.reject(error);
    }
);

export default api;