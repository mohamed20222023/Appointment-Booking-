import { mapEnumToOptions } from '@abp/ng.core';

export enum AppointmentStatus {
  Scheduled = 1,
  Completed = 2,
  Cancelled = 3,
}

export const appointmentStatusOptions = mapEnumToOptions(AppointmentStatus);
