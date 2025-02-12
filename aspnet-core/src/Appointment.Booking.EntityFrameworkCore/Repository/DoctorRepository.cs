using Appointment.Booking.Doctors;
using Appointment.Booking.EntityFrameworkCore;
using Appointment.Booking.IRepository;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Appointment.Booking.Repository;

public class DoctorRepository : EfCoreRepository<BookingDbContext, Doctor, int>, IDoctorRepository
{
    public DoctorRepository(IDbContextProvider<BookingDbContext> dbContextProvider) : base(dbContextProvider) {}

    public async Task<IQueryable<Doctor>> GetAllDoctorsAsync()
    {
        var dbContext = await GetDbContextAsync();
        return dbContext.Set<Doctor>().AsQueryable();
    }
}
