import axios from './axios';
import type { Appointment } from '../types/api';

export const appointmentsApi = {
  getAll: async () => {
    const response = await axios.get<Appointment[]>('/Appointments/GetAll');
    return response.data;
  },

  getById: async (appointmentId: string) => {
    const response = await axios.get<Appointment>(`/Appointments/GetById?appointmentId=${appointmentId}`);
    return response.data;
  },

  add: async (data: Omit<Appointment, 'id'>) => {
    const response = await axios.post<Appointment>('/Appointments/Add', data);
    return response.data;
  },

  update: async (data: Appointment) => {
    const response = await axios.put<Appointment>('/Appointments/Update', data);
    return response.data;
  },

  delete: async (appointmentId: string) => {
    const response = await axios.delete('/Appointments/Delete', {
      data: { id: appointmentId }
    });
    return response.data;
  }
};