using Appointment.Booking.Appointments;
using Appointment.Booking.Common;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Appointment.Booking.IRepository;


public interface IAppointmentRepository : IRepository<AppointmentEntity, int>
{
    Task<IQueryable<AppointmentEntity>> GetAppointmentsForPatientAsync(int patientId);
    Task<IQueryable<AppointmentEntity>> GetAppointmentsForDoctorAsync(int doctorId);
    Task<IQueryable<AppointmentEntity>> GetUpcomingAppointmentsForPatientAsync(int patientId);
    Task<IQueryable<AppointmentEntity>> GetAppointmentsForDoctorWithinDateRangeAsync(int doctorId, DateTime? startDate, DateTime? endDate);
    Task<IQueryable<PopularAppointmentType>> GetPopularAppointmentTypesForDoctorAsync(int doctorId);
    Task<IQueryable<AppointmentGroupedByDoctor>> GetAppointmentCountsGroupedByDoctorAndStatusAsync();
}