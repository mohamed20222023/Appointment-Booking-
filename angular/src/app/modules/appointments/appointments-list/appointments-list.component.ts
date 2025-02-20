import { Component, OnInit, OnDestroy } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Subscription } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { AppointmentService, PatientService, DoctorService } from '@proxy/controllers';
import { CommonModule } from '@angular/common';
import { NgxPaginationModule } from 'ngx-pagination';
import { FormsModule } from '@angular/forms';
import { AddAppointmentDto, AppointmentDto, AppointmentLookupsDto } from '@proxy/appointment/dto';
import { DoctorLookupDto } from '@proxy/doctors/dto';
import { PatientLookupDto } from '@proxy/patients/dto';

@Component({
  selector: 'app-appointments-list',
  standalone: true,
  imports: [CommonModule ,FormsModule, NgxPaginationModule],
  templateUrl: './appointments-list.component.html',
  styleUrl: './appointments-list.component.scss'
})
export class AppointmentsListComponent implements OnInit, OnDestroy {
  appointments: AppointmentDto[] = [];
  doctors: DoctorLookupDto[] = [];
  patients: PatientLookupDto[] = [];
  appointmentTypes: any[] = [];
  appointment: AddAppointmentDto = {
    appointmentDate: '',
    status: 1,
    patientId: 0,
    doctorId: 0,
    appointmentTypeId: 0
  };

  currentPage: number = 1;
  pageSize: number = 5;
  private subscriptions: Subscription = new Subscription();

  constructor(
    private appointmentService: AppointmentService,
    private doctorService: DoctorService,
    private patientService: PatientService,
    private toastr: ToastrService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.loadAppointments();
    this.loadLookups();
  }

  loadAppointments(): void {
    this.subscriptions.add(
      this.appointmentService.getAppointments().subscribe((res) => {  
        this.appointments = res.map(appointment => ({
          ...appointment,
          formattedDate: this.formatDate(appointment.appointmentDate),
          formattedTime: this.formatTime(appointment.appointmentDate)
        }));
      })
    );
  }
  
  formatDate(dateString: string | null): string {
    if (!dateString) return '';
    let date = new Date(dateString);
    if (isNaN(date.getTime())) return '';
    return date.toLocaleDateString('en-GB', { day: 'numeric', month: 'short' });
  }
  
  formatTime(dateString: string | null): string {
    if (!dateString) return '';
    let date = new Date(dateString);
    if (isNaN(date.getTime())) return '';
    return date.toLocaleTimeString('en-US', { hour: '2-digit', minute: '2-digit', hour12: true });
  }
  
  

  loadLookups(): void {
    this.subscriptions.add(
      this.appointmentService.getAppointmentLookups().subscribe((res: AppointmentLookupsDto) => {
        this.appointmentTypes = res.appointmentTypes;
      })
    );

    this.subscriptions.add(
      this.doctorService.getAllDoctorsLookups().subscribe((res: DoctorLookupDto[]) => {
        this.doctors = res;
      })
    );

    this.subscriptions.add(
      this.patientService.getAllPatientsLookups().subscribe((res: PatientLookupDto[]) => {
        this.patients = res;
      })
    );
  }

  openModal(content: any) {
    this.modalService.open(content, { centered: true, backdrop: 'static', keyboard: false });
  }

  addAppointment(modal: any): void {
    if (!this.appointment.appointmentDate) {
      this.toastr.error('Please select a valid date and time.', 'Error');
      return;
    }
  
    let selectedDate = new Date(this.appointment.appointmentDate);
    selectedDate.setHours(selectedDate.getHours() + 2);
    let formattedDate = selectedDate.toISOString();
  
    let appointmentToSend = {
      ...this.appointment,
      appointmentDate: formattedDate
    };
  
    this.subscriptions.add(
      this.appointmentService.addAppointment(appointmentToSend).subscribe({
        next: (response: boolean) => {
          if (response) {
            this.toastr.success('Appointment added successfully!', 'Success');
          } else {
            this.toastr.error('Doctor is not available at this time. Please select another time.', 'Error');
          }
    
          this.loadAppointments();
          modal.dismiss();
          this.resetAppointmentForm();
        },
        error: (errorResponse: any) => {
          let errorMessage = 'Failed to add appointment.';
    
          if (errorResponse.error && errorResponse.error.error && errorResponse.error.error.message) {
            errorMessage = errorResponse.error.error.message;
          }
    
          this.toastr.error(errorMessage, 'Error');
        }
      })
    );
    
    
  }
  
  

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  resetAppointmentForm(): void {
    this.appointment = {
      appointmentDate: '',
      status: 1,
      patientId: 0,
      doctorId: 0,
      appointmentTypeId: 0
    };
  }
  
    getStatusClass(status: string): string {
      switch (status) {
        case 'Scheduled':
          return 'badge bg-primary';
        case 'Completed':
          return 'badge bg-success';
        case 'Cancelled':
          return 'badge bg-danger';
        default:
          return 'badge bg-secondary';
      }
    }
  
    getAppointmentTypeClass(type: string): string {
      switch (type) {
        case 'Consultation':
          return 'badge bg-info';
        case 'Checkup':
          return 'badge bg-warning';
        case 'Follow-up':
          return 'badge bg-dark';
        case 'Emergency':
          return 'badge bg-danger';
        default:
          return 'badge bg-secondary';
      }
    }
}
