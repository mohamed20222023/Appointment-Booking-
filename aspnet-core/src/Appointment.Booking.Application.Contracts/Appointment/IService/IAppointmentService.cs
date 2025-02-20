using Appointment.Booking.Appointment.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.Booking.Appointment.IService;


public interface IAppointmentService
{
    Task<bool> AddAppointmentAsync(AddAppointmentDto dto);
    Task<List<AppointmentDto>> GetAllAppointmentsAsync();
    Task<AppointmentLookupsDto> GetAppointmentLookupsAsync();
    Task<List<AppointmentDto>> GetAppointmentsForPatientAsync(int patientId);
    Task<List<AppointmentDto>> GetAppointmentsForDoctorAsync(int doctorId);
    Task<List<AppointmentWithDoctorPatientDto>> GetUpcomingAppointmentsForPatientAsync(int patientId);
    Task<List<AppointmentGroupedByDoctorDto>> GetAppointmentCountsGroupedByDoctorAndStatusAsync();
    Task<List<AppointmentWithDateRangeDto>> GetAppointmentsForDoctorWithinDateRangeAsync(int doctorId, DateTime? startDate, DateTime? endDate);
    Task<List<PopularAppointmentTypeDto>> GetPopularAppointmentTypesForDoctorAsync(int doctorId);
}