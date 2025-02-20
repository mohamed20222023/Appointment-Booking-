using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Appointment.Booking.Doctors;

public interface IDoctorRepository : IRepository<Doctor, int>
{
    Task<IQueryable<Doctor>> GetAllDoctorsAsync();
    Task<List<Doctor>> GetAllDoctorsLookupsAsync();
    Task<List<DoctorAvailability>> GetDoctorAvailabilityAsync(int doctorId);
}
