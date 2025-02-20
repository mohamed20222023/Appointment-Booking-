using Appointment.Booking.Appointment.Dto;
using Appointment.Booking.Appointment.IService;
using Appointment.Booking.Appointments;
using Appointment.Booking.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Appointment.Booking.Appointment
{
    [RemoteService(false)]
    public class AppointmentService : ApplicationService, IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }


        public async Task<bool> AddAppointmentAsync(AddAppointmentDto dto)
        {
            bool isDoctorAvailable = await _appointmentRepository.IsDoctorAvailableAsync(dto.DoctorId, dto.AppointmentDate);

            if (!isDoctorAvailable)
            {
                return false;
            }

            var appointmentEntity = new AppointmentEntity(0)
            {
                AppointmentDate = dto.AppointmentDate,
                Status = dto.Status,
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                AppointmentTypeId = dto.AppointmentTypeId
            };

            bool isAdded = await _appointmentRepository.AddAppointmentAsync(appointmentEntity);

            return isAdded ? true: false;
        }

        public async Task<List<AppointmentDto>> GetAllAppointmentsAsync()
        {
            var appointments = await _appointmentRepository.GetAllAppointmentsAsync();
            return ObjectMapper.Map<List<AppointmentEntity>, List<AppointmentDto>>(appointments);
        }

        public async Task<List<AppointmentDto>> GetAppointmentsForPatientAsync(int patientId)
        {
            var queryable = await _appointmentRepository.GetAppointmentsForPatientAsync(patientId);
            var appointments = await queryable.ToListAsync();

            if (!appointments.Any())
                throw new NotFoundException(patientId);

            return ObjectMapper.Map<List<AppointmentEntity>, List<AppointmentDto>>(appointments);
        }

        public async Task<List<AppointmentDto>> GetAppointmentsForDoctorAsync(int doctorId)
        {
            var queryable = await _appointmentRepository.GetAppointmentsForDoctorAsync(doctorId);
            var appointments = await queryable.ToListAsync();

            if (!appointments.Any())
                throw new NotFoundException(doctorId);

            return ObjectMapper.Map<List<AppointmentEntity>, List<AppointmentDto>>(appointments);
        }

        public async Task<List<AppointmentWithDoctorPatientDto>> GetUpcomingAppointmentsForPatientAsync(int patientId)
        {
            var queryable = await _appointmentRepository.GetUpcomingAppointmentsForPatientAsync(patientId);
            var appointments = await queryable.ToListAsync();

            if (!appointments.Any())
                throw new NotFoundException(patientId);

            return ObjectMapper.Map<List<AppointmentEntity>, List<AppointmentWithDoctorPatientDto>>(appointments);
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

            return ObjectMapper.Map<List<AppointmentEntity>, List<AppointmentWithDateRangeDto>>(appointments);
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

        public async Task<AppointmentLookupsDto> GetAppointmentLookupsAsync()
        {
            var (appointmentTypes, appointmentStatuses) = await _appointmentRepository.GetAppointmentLookupsAsync();

            var appointmentTypeDtos = appointmentTypes.Select(a => new AppointmentTypeLookupDto
            {
                Id = a.Id,
                Name = a.TypeName
            }).ToList();

            var appointmentStatusDtos = appointmentStatuses.Select(status => new AppointmentStatusLookupDto
            {
                Id = (int)status,
                Name = status.ToString()
            }).ToList();

            return new AppointmentLookupsDto
            {
                AppointmentTypes = appointmentTypeDtos,
                AppointmentStatuses = appointmentStatusDtos
            };
        }


    }
}
