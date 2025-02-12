using Appointment.Booking.Appointments;
using Appointment.Booking.Common;
using Appointment.Booking.Dtos;
using Appointment.Booking.IRepository;
using Appointment.Booking.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Appointment.Booking.Service
{
    [RemoteService(false)]
    public class AppointmentService : ApplicationService , IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<List<AppointmentDto>> GetAppointmentsForPatientAsync(Guid tenantId, int patientId)
        {
            var queryable = await _appointmentRepository.GetAppointmentsForPatientAsync(tenantId, patientId);
            var appointments = await queryable.ToListAsync();

            if (!appointments.Any())
                throw new NotFoundException(patientId);

            return ObjectMapper.Map<List<AppointmentEntity> , List <AppointmentDto>>(appointments);
        }

        public async Task<List<AppointmentDto>> GetAppointmentsForDoctorAsync(int doctorId)
        {
            var queryable = await _appointmentRepository.GetAppointmentsForDoctorAsync(doctorId);
            var appointments = await queryable.ToListAsync();

            if (!appointments.Any())
                throw new NotFoundException(doctorId);

            return ObjectMapper.Map<List<AppointmentEntity> , List <AppointmentDto>>(appointments);
        }

        public async Task<List<AppointmentWithDoctorPatientDto>> GetUpcomingAppointmentsForPatientAsync(Guid tenantId, int patientId)
        {
            var queryable = await _appointmentRepository.GetUpcomingAppointmentsForPatientAsync(tenantId, patientId);
            var appointments = await queryable.ToListAsync();

            if (!appointments.Any())
                throw new NotFoundException(patientId);

            return ObjectMapper.Map<List<AppointmentEntity>,List <AppointmentWithDoctorPatientDto>>(appointments);
        }

        public async Task<List<AppointmentGroupedByDoctorDto>> GetAppointmentCountsGroupedByDoctorAndStatusAsync()
        {
            var queryable = await _appointmentRepository.GetAppointmentCountsGroupedByDoctorAndStatusAsync();
            var groupedAppointments = await queryable.ToListAsync();

            return groupedAppointments.Select(a => new AppointmentGroupedByDoctorDto
            {
                DoctorName = a.DoctorName,
                Status = a.Status,
                StatusValue = a.Status.ToString(),
                AppointmentCount = a.AppointmentCount
            }).ToList();
        }



        public async Task<List<AppointmentWithDateRangeDto>> GetAppointmentsForDoctorWithinDateRangeAsync(int doctorId, DateTime? startDate, DateTime? endDate)
        {
            var queryable = await _appointmentRepository.GetAppointmentsForDoctorWithinDateRangeAsync(doctorId, startDate, endDate);
            var appointments = await queryable.ToListAsync();

            if (!appointments.Any())
                throw new NotFoundException(doctorId);

            return ObjectMapper.Map<List<AppointmentEntity> ,List <AppointmentWithDateRangeDto>>(appointments);
        }

        public async Task<List<PopularAppointmentTypeDto>> GetPopularAppointmentTypesForDoctorAsync(int doctorId)
        {
            var queryable = await _appointmentRepository.GetPopularAppointmentTypesForDoctorAsync(doctorId);
            var popularAppointments = await queryable.ToListAsync();

            if (!popularAppointments.Any())
                throw new NotFoundException(doctorId);

            return popularAppointments.Select(a => new PopularAppointmentTypeDto
            {
                AppointmentType = a.AppointmentType,
                AppointmentCount = a.AppointmentCount
            }).ToList();
        }

    }
}
