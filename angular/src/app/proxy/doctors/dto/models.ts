
export interface DoctorAvailabilityDto {
  name?: string;
  day?: string;
  startTime?: string;
  endTime?: string;
}

export interface DoctorDto {
  id: number;
  name?: string;
  specialization?: string;
  email?: string;
  phoneNumber?: string;
}

export interface DoctorLookupDto {
  id: number;
  name?: string;
}
