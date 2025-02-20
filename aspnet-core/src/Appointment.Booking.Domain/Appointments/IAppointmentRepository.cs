using Appointment.Booking.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Appointment.Booking.Appointments;


public interface IAppointmentRepository : IRepository<AppointmentEntity, int>
{
    Task<bool> AddAppointmentAsync(AppointmentEntity appointment);
    Task<List<AppointmentEntity>> GetAllAppointmentsAsync();
    Task<(List<AppointmentType>, List<AppointmentStatus>)> GetAppointmentLookupsAsync();
    Task<IQueryable<AppointmentEntity>> GetAppointmentsForPatientAsync(int patientId);
    Task<IQueryable<AppointmentEntity>> GetAppointmentsForDoctorAsync(int doctorId);
    Task<IQueryable<AppointmentEntity>> GetUpcomingAppointmentsForPatientAsync(int patientId);
    Task<IQueryable<AppointmentEntity>> GetAppointmentsForDoctorWithinDateRangeAsync(int doctorId, DateTime? startDate, DateTime? endDate);
    Task<IQueryable<PopularAppointmentType>> GetPopularAppointmentTypesForDoctorAsync(int doctorId);
    Task<IQueryable<AppointmentGroupedByDoctor>> GetAppointmentCountsGroupedByDoctorAndStatusAsync();
    Task<bool> IsDoctorAvailableAsync(int doctorId, DateTime appointmentDate);
}