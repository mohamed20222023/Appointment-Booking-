import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { AppointmentService, PatientService } from '@proxy/controllers';
import { DoctorService } from '@proxy/controllers';
import { AddAppointmentDto, AppointmentLookupsDto } from '@proxy/appointment/dto';
import { DoctorLookupDto } from '@proxy/doctors/dto';
import { PatientLookupDto } from '@proxy/patients/dto';

@Component({
  selector: 'app-add-appointment',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    ToastrModule
  ],
  templateUrl: './add-appointment.component.html',
  styleUrls: ['./add-appointment.component.scss']
})
export class AddAppointmentComponent implements OnInit {
  appointment: AddAppointmentDto = {
    appointmentDate: '',
    status: 1,
    patientId: 0,
    doctorId: 0,
    appointmentTypeId: 0
  };

  appointmentTypes: any[] = [];
  doctors: DoctorLookupDto[] = [];
  patients: PatientLookupDto[] = [];

  constructor(
    private appointmentService: AppointmentService,
    private doctorService: DoctorService,
    private patientService: PatientService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.loadLookups();
  }

  loadLookups(): void {
    this.appointmentService.getAppointmentLookups().subscribe((res: AppointmentLookupsDto) => {
      this.appointmentTypes = res.appointmentTypes;
    });

    this.doctorService.getAllDoctorsLookups().subscribe((res: DoctorLookupDto[]) => {
      this.doctors = res;
    });

    this.patientService.getAllPatientsLookups().subscribe((res: PatientLookupDto[]) => {
      this.patients = res;
    });
  }

  addAppointment(): void {
    this.appointmentService.addAppointment(this.appointment).subscribe({
      next: (response: boolean) => {
        if (!response) {
          this.toastr.success('Appointment added successfully!', 'Success');
        } else {
          this.toastr.success('Doctor is not available at this time. Please select another time.', 'Success');
        }
        this.router.navigate(['/appointments']);
      },
      error: () => {
        this.toastr.error('Failed to add appointment.', 'Error');
      }
    });
  }
  
  cancel(): void {
    this.toastr.info('Appointment creation cancelled.', 'Info');
    this.router.navigate(['/appointments']);
  }
}
