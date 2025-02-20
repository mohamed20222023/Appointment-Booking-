import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DoctorAvailabilityDto, DoctorDto, DoctorLookupDto } from '../doctors/dto/models';

@Injectable({
  providedIn: 'root',
})
export class DoctorService {
  apiName = 'Default';
  

  getAllDoctors = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DoctorDto[]>({
      method: 'GET',
      url: '/api/doctors/all',
    },
    { apiName: this.apiName,...config });
  

  getAllDoctorsLookups = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DoctorLookupDto[]>({
      method: 'GET',
      url: '/api/doctors/Lookups',
    },
    { apiName: this.apiName,...config });
  

  getDoctorAvailability = (doctorId: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DoctorAvailabilityDto[]>({
      method: 'GET',
      url: `/api/doctors/${doctorId}/availability`,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
