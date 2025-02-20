using Appointment.Booking.Doctors;
using Appointment.Booking.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Appointment.Booking.DoctorRepository;

public class DoctorRepository : EfCoreRepository<BookingDbContext, Doctor, int>, IDoctorRepository
{
    public DoctorRepository(IDbContextProvider<BookingDbContext> dbContextProvider) : base(dbContextProvider) { }

    public async Task<IQueryable<Doctor>> GetAllDoctorsAsync()
    {
        var dbContext = await GetDbContextAsync();
        return dbContext.Set<Doctor>().AsQueryable();
    }

    public async Task<List<Doctor>> GetAllDoctorsLookupsAsync()
    {
        var dbContext = await GetDbContextAsync();
        return await dbContext.Set<Doctor>()
            .Select(d => new Doctor(d.Id)
            {
                Name = d.Name
            })
            .ToListAsync();
    }


    public async Task<List<DoctorAvailability>> GetDoctorAvailabilityAsync(int doctorId)
    {
        var dbContext = await GetDbContextAsync();
        return await dbContext.Set<DoctorAvailability>().Include( d => d.Doctor)
            .Where(da => da.DoctorId == doctorId)
            .ToListAsync();
    }


}
