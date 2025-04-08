import axios from './axios';
import {Doctor, DoctorGetAllResponseDto} from '../types/api';

export const doctorsApi = {
  getAll: async () => {
    const response = await axios.get<Doctor[]>('/Doctors/GetAll');
    return response.data;
  },

  getById: async (doctorId: string) => {
    const response = await axios.get<Doctor>(`/Doctors/GetById?doctorId=${doctorId}`);
    return response.data;
  },

  getAllByHospitalId: async (doctorId: string) => {
    const response = await axios.get<DoctorGetAllResponseDto[]>(`/Doctors/GetAllByHospitalId?hospitalId=${doctorId}`);
    return response.data;
  }
};