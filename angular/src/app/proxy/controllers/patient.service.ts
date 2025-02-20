import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { PatientDto, PatientLookupDto } from '../patients/dto/models';

@Injectable({
  providedIn: 'root',
})
export class PatientService {
  apiName = 'Default';
  

  getAllPatients = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, PatientDto[]>({
      method: 'GET',
      url: '/api/patients/all',
    },
    { apiName: this.apiName,...config });
  

  getAllPatientsLookups = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, PatientLookupDto[]>({
      method: 'GET',
      url: '/api/patients/Lookups',
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
