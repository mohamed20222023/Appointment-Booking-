using Appointment.Booking.Patients;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Appointment.Booking.Data.Seeding;

public class PatientDataSeeder : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Patient, int> _patientRepository;

    public PatientDataSeeder(IRepository<Patient, int> patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _patientRepository.GetCountAsync() == 0)
        {
            await _patientRepository.InsertManyAsync(new[]
            {
                new Patient(1) { FullName = "Omar Yassin", Email = "omar1@example.com", PhoneNumber = "1111111111" },
                new Patient(2) { FullName = "Tarek Hisham", Email = "tarek2@example.com", PhoneNumber = "2222222222" },
                new Patient(3) { FullName = "Hisham Adel", Email = "hisham3@example.com", PhoneNumber = "3333333333" },
                new Patient(4) { FullName = "Amr Saeed", Email = "amr4@example.com", PhoneNumber = "4444444444" },
                new Patient(5) { FullName = "Kareem Fathy", Email = "kareem5@example.com", PhoneNumber = "5555555555" },
                new Patient(6) { FullName = "Ehab Mostafa", Email = "ehab6@example.com", PhoneNumber = "6666666666" },
                new Patient(7) { FullName = "Mostafa Nabil", Email = "mostafa7@example.com", PhoneNumber = "7777777777" },
                new Patient(8) { FullName = "Walid Gamal", Email = "walid8@example.com", PhoneNumber = "8888888888" },
                new Patient(9) { FullName = "Rami Hussein", Email = "rami9@example.com", PhoneNumber = "9999999999" },
                new Patient(10) { FullName = "Nader Samir", Email = "nader10@example.com", PhoneNumber = "1010101010" }
            });
        }
    }
}
