import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppointmentsListComponent } from './appointments-list/appointments-list.component';
import { AddAppointmentComponent } from './add-appointment/add-appointment.component';

const routes: Routes = [
    { 
      path: '', 
      pathMatch:'full',
      component:AppointmentsListComponent
    },
    { 
      path: 'add', 
      pathMatch:'full',
      component:AddAppointmentComponent
    }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppointmentsRoutingModule { }
