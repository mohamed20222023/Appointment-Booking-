import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DoctorAvailabilitiesComponent } from './modules/doctors/doctor-availabilities/doctor-availabilities.component';
import { AddAppointmentComponent } from './modules/appointments/add-appointment/add-appointment.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
  },  {
    path: 'doctors',
    loadChildren: () => import('./modules/doctors/doctors.module').then(m => m.DoctorsModule),
  },  {
    path: 'appointments',
    loadChildren: () => import('./modules/appointments/appointments.module').then(m => m.AppointmentsModule),
  },
  { 
    path: 'doctors/:doctorId/availability', component: DoctorAvailabilitiesComponent 
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(m => m.AccountModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule.forLazy()),
  },
  {
    path: 'tenant-management',
    loadChildren: () =>
      import('@abp/ng.tenant-management').then(m => m.TenantManagementModule.forLazy()),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {})],
  exports: [RouterModule],
})
export class AppRoutingModule {}
