using Appointment.Booking.Doctors;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Appointment.Booking.IRepository;

public interface IDoctorRepository : IRepository<Doctor, int>
{
    Task<IQueryable<Doctor>> GetAllDoctorsAsync();
}
