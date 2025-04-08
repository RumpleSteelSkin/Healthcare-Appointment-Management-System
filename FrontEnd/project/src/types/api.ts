// Authentication Types
export interface LoginRequest {
    userNameOrEmail: string;
    password: string;
}


export interface UserResponseDto {
    "id": string,
    "userName": string,
    "fullName": string,
    "email": string
}


export interface LoginResponse {
    token: string;
    tokenExpiration: string;
}

export interface RegisterRequest {
    userName: string;
    firstName: string;
    lastName: string;
    email: string;
    birthDate: string;
    password: string;
}

// Hospital Types
export interface Hospital {
    id: string;
    name: string;
    address: string;
    city: string;
}

// Doctor Types
export interface Doctor {
    id: string;
    firstName: string;
    lastName: string;
    specialty: string;
    hospitalId: string;
}

export interface DoctorGetAllResponseDto {
    id: string;
    fullName: string;
    specialty: string;
}

// Appointment Types
export interface Appointment {
    id: string;
    appointmentDate: string;
    notes: string;
    doctorId: string;
    patientId: string;
}

export interface AppointmentDto {
    id: string;
    patientFullName: string;
    doctorFullName: string;
    appointmentDate: string;
    appointmentDay: string;
    appointmentMonth: string;
    appointmentYear: string;
    notes: string;
}


// Error Types
export interface ValidationError {
    type: string;
    title: string;
    status: number;
    errors: Array<{
        property: string;
        errors: string[];
    }>;
}

export interface BusinessError {
    type: string;
    title: string;
    status: number;
    detail: string;
}