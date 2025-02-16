using Appointment.Booking.Patients;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Appointment.Booking.IRepository;

public interface IPatientRepository : IRepository<Patient, int>
{
    Task<IQueryable<Patient>> GetAllPatientsAsync();
    Task<List<object>> GetAllPatientsLookupsAsync();
}
