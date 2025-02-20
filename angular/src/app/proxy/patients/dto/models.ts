
export interface PatientDto {
  id: number;
  fullName?: string;
  email?: string;
  phoneNumber?: string;
}

export interface PatientLookupDto {
  id: number;
  name?: string;
}
