using Appointment.Booking.EntityFrameworkCore;
using Appointment.Booking.IRepository;
using Appointment.Booking.Patients;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Appointment.Booking.Repository;

public class PatientRepository : EfCoreRepository<BookingDbContext, Patient, int>, IPatientRepository
{
    public PatientRepository(IDbContextProvider<BookingDbContext> dbContextProvider) : base(dbContextProvider) {}

    public async Task<IQueryable<Patient>> GetAllPatientsAsync()
    {
        var dbContext = await GetDbContextAsync();
        return dbContext.Set<Patient>().AsQueryable();
    }
}
