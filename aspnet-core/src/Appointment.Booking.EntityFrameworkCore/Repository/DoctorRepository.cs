using Appointment.Booking.Doctors;
using Appointment.Booking.EntityFrameworkCore;
using Appointment.Booking.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

    public async Task<List<object>> GetAllDoctorsLookupsAsync()
    {
        var dbContext = await GetDbContextAsync();
        return await dbContext.Set<Doctor>()
            .Select(d => new { Id = d.Id, Name = d.Name })
            .ToListAsync<object>();
    }

    public async Task<List<DoctorAvailability>> GetDoctorAvailabilityAsync(int doctorId)
    {
        var dbContext = await GetDbContextAsync();
        return await dbContext.Set<DoctorAvailability>()
            .Where(da => da.DoctorId == doctorId)
            .ToListAsync();
    }


}
