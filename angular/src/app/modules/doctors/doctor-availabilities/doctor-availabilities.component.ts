import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DoctorService } from '@proxy/controllers';
import { DoctorAvailabilityDto } from '@proxy/doctors/dto';

@Component({
  selector: 'app-doctor-availabilities',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './doctor-availabilities.component.html',
  styleUrl: './doctor-availabilities.component.scss'
})
export class DoctorAvailabilitiesComponent implements OnInit {

  doctorId!: number;
  availability: DoctorAvailabilityDto[] = [];

  constructor(private route: ActivatedRoute, private doctorService: DoctorService) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.doctorId = +params['doctorId'];
      this.loadAvailability();
    });
  }

  loadAvailability(): void {
    this.doctorService.getDoctorAvailability(this.doctorId).subscribe((res) => {
      this.availability = res;
    });
  }

  goBack(): void {
    window.history.back();
  }

}
