import type { AppointmentStatus } from '../common/appointment-status.enum';

export interface AddAppointmentDto {
  appointmentDate?: string;
  status: AppointmentStatus;
  patientId: number;
  doctorId: number;
  appointmentTypeId: number;
}

export interface AppointmentDto {
  id: number;
  appointmentDate?: string;
  statusValue?: string;
  status: AppointmentStatus;
  patientFullName?: string;
  doctorName?: string;
  appointmentType?: string;
}

export interface AppointmentGroupedByDoctorDto {
  doctorName?: string;
  statusValue?: string;
  status: AppointmentStatus;
  appointmentCount: number;
}

export interface AppointmentWithDateRangeDto {
  id: number;
  appointmentDate?: string;
  patientTenantId: number;
  patientId: number;
  patientName?: string;
  statusValue?: string;
  status: AppointmentStatus;
}

export interface AppointmentWithDoctorPatientDto {
  id: number;
  appointmentDate?: string;
  statusValue?: string;
  status: AppointmentStatus;
  doctorName?: string;
  appointmentType?: string;
  patientName?: string;
}

export interface DoctorDto {
  id: number;
  name?: string;
  specialization?: string;
  email?: string;
  phoneNumber?: string;
}

export interface PatientDto {
  id: number;
  fullName?: string;
  email?: string;
  phoneNumber?: string;
}

export interface PopularAppointmentTypeDto {
  appointmentType?: string;
  appointmentCount: number;
}
