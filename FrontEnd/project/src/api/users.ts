import axios from './axios';
import {UserResponseDto} from "../types/api.ts";

export const usersApi = {
    getAll: async () => {
        const response = await axios.get<UserResponseDto[]>('/Authentications/GetAllUsers');
        return response.data;
    },

    getUserDetailsByUserId: async (id: string) => {
        return (await axios.get<UserResponseDto[]>('/Authentications/GetUserDetailsById', {
            headers: {
                'Content-Type': 'application/json',
                'Accept': '*/*',
            },
            data: {
                userId: id
            }
        })).data;
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
    },

    updateUser: async (userId: string, userName: string, firstName: string, lastName: string, birthDate: string, email: string, password: string) => {
        const response = await axios.put('/Authentications/UpdateUser', {
            headers: {
                'Content-Type': 'application/json',
                'Accept': '*/*',
            },
            data: {
                Id: userId,
                userName: userName,
                firstName: firstName,
                lastName: lastName,
                birthDate: birthDate,
                email: email,
                password: password
            }
        });
        return response.data;
    }


};