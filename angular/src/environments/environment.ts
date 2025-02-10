import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Booking',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44311/',
    redirectUri: baseUrl,
    clientId: 'Booking_App',
    responseType: 'code',
    scope: 'offline_access Booking',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44311',
      rootNamespace: 'Appointment.Booking',
    },
  },
} as Environment;
