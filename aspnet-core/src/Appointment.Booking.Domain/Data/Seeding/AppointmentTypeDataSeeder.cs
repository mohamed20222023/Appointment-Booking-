using Appointment.Booking.Appointments;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Appointment.Booking.Data.Seeding;

public class AppointmentTypeDataSeeder : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<AppointmentType, int> _appointmentTypeRepository;

    public AppointmentTypeDataSeeder(IRepository<AppointmentType, int> appointmentTypeRepository)
    {
        _appointmentTypeRepository = appointmentTypeRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (!await _appointmentTypeRepository.AnyAsync())
        {
            await _appointmentTypeRepository.InsertManyAsync(new[]
            {
                new AppointmentType (1) { TypeName = "Consultation" },
                new AppointmentType (2) { TypeName = "Follow-up" }
            });
        }
    }
}

