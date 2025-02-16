import { Component, OnInit } from '@angular/core';
import { DoctorService } from '../../../proxy/controllers/doctor.service';

@Component({
  selector: 'app-doctors-list',
  standalone: true,
  imports: [],
  templateUrl: './doctors-list.component.html',
  styleUrl: './doctors-list.component.scss'
})
export class DoctorsListComponent implements OnInit {
  doctors: any[] = [];

  constructor(private doctorService: DoctorService) {}

  ngOnInit(): void {
    this.doctorService.getAllDoctors().subscribe((res) => {
      this.doctors = res;
    });
  }
}

