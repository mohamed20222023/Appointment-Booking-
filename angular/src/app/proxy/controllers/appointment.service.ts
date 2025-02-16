import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { AddAppointmentDto, AppointmentDto, AppointmentGroupedByDoctorDto, AppointmentWithDateRangeDto, AppointmentWithDoctorPatientDto, PopularAppointmentTypeDto } from '../dtos/models';

@Injectable({
  providedIn: 'root',
})
export class AppointmentService {
  apiName = 'Default';
  

  addAppointment = (request: AddAppointmentDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, boolean>({
      method: 'POST',
      url: '/api/appointments/add',
      body: request,
    },
    { apiName: this.apiName,...config });
  

  getAppointmentCountsGroupedByDoctorAndStatus = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppointmentGroupedByDoctorDto[]>({
      method: 'GET',
      url: '/api/appointments/grouped-by-doctor',
    },
    { apiName: this.apiName,...config });
  

  getAppointmentLookups = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, Record<string, object>>({
      method: 'GET',
      url: '/api/appointments/lookup',
    },
    { apiName: this.apiName,...config });
  

  getAppointmentsForDoctor = (doctorId: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppointmentDto[]>({
      method: 'GET',
      url: `/api/appointments/doctor/${doctorId}`,
    },
    { apiName: this.apiName,...config });
  

  getAppointmentsForDoctorWithinDateRange = (doctorId: number, startDate?: string, endDate?: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppointmentWithDateRangeDto[]>({
      method: 'GET',
      url: `/api/appointments/doctor/${doctorId}/date-range`,
      params: { startDate, endDate },
    },
    { apiName: this.apiName,...config });
  

  getAppointmentsForPatient = (patientId: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppointmentDto[]>({
      method: 'GET',
      url: `/api/appointments/patient/${patientId}`,
    },
    { apiName: this.apiName,...config });
  

  getPopularAppointmentTypesForDoctor = (doctorId: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PopularAppointmentTypeDto[]>({
      method: 'GET',
      url: `/api/appointments/doctor/${doctorId}/popular-appointment-types`,
    },
    { apiName: this.apiName,...config });
  

  getUpcomingAppointmentsForPatient = (patientId: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppointmentWithDoctorPatientDto[]>({
      method: 'GET',
      url: `/api/appointments/patient/upcoming/${patientId}`,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
