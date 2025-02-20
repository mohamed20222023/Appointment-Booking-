import { Component, OnInit } from '@angular/core';
import { DoctorService } from '../../../proxy/controllers/doctor.service';

import { Router } from '@angular/router';
import { NgxPaginationModule } from 'ngx-pagination';
import { CommonModule } from '@angular/common';
import { DoctorDto } from '@proxy/doctors/dto';

@Component({
  selector: 'app-doctors-list',
  standalone: true,
  imports: [NgxPaginationModule , CommonModule],
  templateUrl: './doctors-list.component.html',
  styleUrl: './doctors-list.component.scss'
})
export class DoctorsListComponent implements OnInit {
  doctors: DoctorDto[] = [];
  currentPage: number = 1;
  pageSize: number = 5;

  constructor(private doctorService: DoctorService, private router: Router) {}

  ngOnInit(): void {
    this.getDoctors();
  }

  getDoctors(): void {
    this.doctorService.getAllDoctors().subscribe((res) => {
      this.doctors = res;
    });
  }

  showAvailability(doctorId: number): void {
    this.router.navigate(['/doctors', doctorId, 'availability']);
  }
}
