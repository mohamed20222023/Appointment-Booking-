using Appointment.Booking.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.Booking.IService;


public interface IAppointmentService
{
    Task<List<AppointmentDto>> GetAppointmentsForPatientAsync(Guid tenantId, int patientId);
    Task<List<AppointmentDto>> GetAppointmentsForDoctorAsync(int doctorId);
    Task<List<AppointmentWithDoctorPatientDto>> GetUpcomingAppointmentsForPatientAsync(Guid tenantId, int patientId);
    Task<List<AppointmentGroupedByDoctorDto>> GetAppointmentCountsGroupedByDoctorAndStatusAsync();
    Task<List<AppointmentWithDateRangeDto>> GetAppointmentsForDoctorWithinDateRangeAsync(int doctorId, DateTime? startDate, DateTime? endDate);
    Task<List<PopularAppointmentTypeDto>> GetPopularAppointmentTypesForDoctorAsync(int doctorId);
}