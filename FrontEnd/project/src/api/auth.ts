import axios from './axios';
import type { LoginRequest, LoginResponse, RegisterRequest } from '../types/api';

export const authApi = {
  login: async (data: LoginRequest) => {
    const response = await axios.post<LoginResponse>('/Authentications/Login', data);
    return response.data;
  },

  register: async (data: RegisterRequest) => {
    const response = await axios.post('/Authentications/Register', data);
    return response.data;
  },

  getCurrentUser: async () => {
    const response = await axios.get('/Authentications/GetCurrentUser');
    return response.data;
  },
};