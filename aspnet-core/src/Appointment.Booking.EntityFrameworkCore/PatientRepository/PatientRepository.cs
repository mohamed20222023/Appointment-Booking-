using Appointment.Booking.EntityFrameworkCore;
using Appointment.Booking.Patients;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Appointment.Booking.PatientRepository;

public class PatientRepository : EfCoreRepository<BookingDbContext, Patient, int>, IPatientRepository
{
    public PatientRepository(IDbContextProvider<BookingDbContext> dbContextProvider) : base(dbContextProvider) { }

    public async Task<IQueryable<Patient>> GetAllPatientsAsync()
    {
        var dbContext = await GetDbContextAsync();
        return dbContext.Set<Patient>().AsQueryable();
    }

    public async Task<List<Patient>> GetAllPatientsLookupsAsync()
    {
        var dbContext = await GetDbContextAsync();
        return await dbContext.Set<Patient>().ToListAsync();
    }


}
