import axios from './axios';
import {UserResponseDto} from "../types/api.ts";

export const usersApi = {
    getAll: async () => {
        const response = await axios.get<UserResponseDto[]>('/Authentications/GetAllUsers');
        return response.data;
    },

    deleteUser: async (userId: string) => {
        const response = await axios.delete('/Authentications/DeleteUser', {
            headers: {
                'Content-Type': 'application/json',
                'Accept': '*/*',
            },
            data: {
                userId: userId
            }
        });
        return response.data;
    }





};