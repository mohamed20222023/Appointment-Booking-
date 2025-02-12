using Appointment.Booking.Doctors;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Appointment.Booking.Data.Seeding;

public class DoctorDataSeeder : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Doctor, int> _doctorRepository;

    public DoctorDataSeeder(IRepository<Doctor, int> doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _doctorRepository.GetCountAsync() == 0)
        {
            await _doctorRepository.InsertManyAsync(new[]
            {
                new Doctor(1) { Name = "Dr. Mohamed Ahmed", Specialization = "Cardiologist", Email = "mohamed1@example.com", PhoneNumber = "1111111111" },
                new Doctor(2) { Name = "Dr. Ahmed Ali", Specialization = "Dermatologist", Email = "ahmed2@example.com", PhoneNumber = "2222222222"},
                new Doctor(3) { Name = "Dr. Ali Hassan", Specialization = "Neurologist", Email = "ali3@example.com", PhoneNumber = "3333333333" },
                new Doctor(4) { Name = "Dr. Youssef Khaled", Specialization = "Orthopedic", Email = "youssef4@example.com", PhoneNumber = "4444444444" },
                new Doctor(5) { Name = "Dr. Omar Ibrahim", Specialization = "Pediatrician", Email = "omar5@example.com", PhoneNumber = "5555555555" },
                new Doctor(6) { Name = "Dr. Hassan Mahmoud", Specialization = "Endocrinologist", Email = "hassan6@example.com", PhoneNumber = "6666666666" },
                new Doctor(7) { Name = "Dr. Khaled Samir", Specialization = "Psychiatrist", Email = "khaled7@example.com", PhoneNumber = "7777777777" },
                new Doctor(8) { Name = "Dr. Ibrahim Zaki", Specialization = "Oncologist", Email = "ibrahim8@example.com", PhoneNumber = "8888888888" },
                new Doctor(9) { Name = "Dr. Mahmoud Tarek", Specialization = "General Practitioner", Email = "mahmoud9@example.com", PhoneNumber = "9999999999" },
                new Doctor(10) { Name = "Dr. Sami Adel", Specialization = "Gastroenterologist", Email = "sami10@example.com", PhoneNumber = "1010101010"}
            });
        }
    }
}
