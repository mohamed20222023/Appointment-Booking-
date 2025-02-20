import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DoctorsListComponent } from './doctors-list/doctors-list.component';
import { DoctorAvailabilitiesComponent } from './doctor-availabilities/doctor-availabilities.component';

const routes: Routes = [
  { 
    path: '', 
    pathMatch:'full',
    component:DoctorsListComponent
  },
  { 
    path: 'doctors/:doctorId/availability', 
    component: DoctorAvailabilitiesComponent 
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DoctorsRoutingModule { }
