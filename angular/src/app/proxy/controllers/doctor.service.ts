import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DoctorDto } from '../dtos/models';

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
    this.restService.request<any, object[]>({
      method: 'GET',
      url: '/api/doctors/Lookups',
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
