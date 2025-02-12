using Appointment.Booking.Doctors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Appointment.Booking.Data.Seeding;

public class DoctorAvailabilityDataSeeder : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<DoctorAvailability, int> _availabilityRepository;

    public DoctorAvailabilityDataSeeder(IRepository<DoctorAvailability, int> availabilityRepository)
    {
        _availabilityRepository = availabilityRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (!await _availabilityRepository.AnyAsync())
        {
            var doctorAvailabilities = new List<DoctorAvailability>
            {
                new DoctorAvailability(1) { Day = "Monday", StartTime = TimeSpan.Parse("09:00:00"), EndTime = TimeSpan.Parse("17:00:00"), DoctorId = 1 },
                new DoctorAvailability(2) { Day = "Tuesday", StartTime = TimeSpan.Parse("10:00:00"), EndTime = TimeSpan.Parse("16:00:00"), DoctorId = 1 },
                new DoctorAvailability(3) { Day = "Wednesday", StartTime = TimeSpan.Parse("08:00:00"), EndTime = TimeSpan.Parse("14:00:00"), DoctorId = 1 },
                new DoctorAvailability(4) { Day = "Thursday", StartTime = TimeSpan.Parse("13:00:00"), EndTime = TimeSpan.Parse("19:00:00"), DoctorId = 1 },
                new DoctorAvailability(5) { Day = "Friday", StartTime = TimeSpan.Parse("09:30:00"), EndTime = TimeSpan.Parse("15:30:00"), DoctorId = 1 },

                new DoctorAvailability(6) { Day = "Monday", StartTime = TimeSpan.Parse("08:30:00"), EndTime = TimeSpan.Parse("15:30:00"), DoctorId = 2 },
                new DoctorAvailability(7) { Day = "Tuesday", StartTime = TimeSpan.Parse("09:00:00"), EndTime = TimeSpan.Parse("16:00:00"), DoctorId = 2 },
                new DoctorAvailability(8) { Day = "Wednesday", StartTime = TimeSpan.Parse("10:00:00"), EndTime = TimeSpan.Parse("18:00:00"), DoctorId = 2 },
                new DoctorAvailability(9) { Day = "Thursday", StartTime = TimeSpan.Parse("11:30:00"), EndTime = TimeSpan.Parse("17:30:00"), DoctorId = 2 },
                new DoctorAvailability(10) { Day = "Friday", StartTime = TimeSpan.Parse("09:00:00"), EndTime = TimeSpan.Parse("14:00:00"), DoctorId = 2 },

                new DoctorAvailability(11) { Day = "Monday", StartTime = TimeSpan.Parse("09:00:00"), EndTime = TimeSpan.Parse("17:00:00"), DoctorId = 3 },
                new DoctorAvailability(12) { Day = "Tuesday", StartTime = TimeSpan.Parse("10:30:00"), EndTime = TimeSpan.Parse("16:30:00"), DoctorId = 3 },
                new DoctorAvailability(13) { Day = "Wednesday", StartTime = TimeSpan.Parse("08:30:00"), EndTime = TimeSpan.Parse("14:30:00"), DoctorId = 3 },
                new DoctorAvailability(14) { Day = "Thursday", StartTime = TimeSpan.Parse("12:00:00"), EndTime = TimeSpan.Parse("18:00:00"), DoctorId = 3 },
                new DoctorAvailability(15) { Day = "Friday", StartTime = TimeSpan.Parse("08:45:00"), EndTime = TimeSpan.Parse("13:45:00"), DoctorId = 3 },

                new DoctorAvailability(16) { Day = "Monday", StartTime = TimeSpan.Parse("07:30:00"), EndTime = TimeSpan.Parse("15:00:00"), DoctorId = 4 },
                new DoctorAvailability(17) { Day = "Tuesday", StartTime = TimeSpan.Parse("11:00:00"), EndTime = TimeSpan.Parse("17:00:00"), DoctorId = 4 },
                new DoctorAvailability(18) { Day = "Wednesday", StartTime = TimeSpan.Parse("09:30:00"), EndTime = TimeSpan.Parse("16:30:00"), DoctorId = 4 },
                new DoctorAvailability(19) { Day = "Thursday", StartTime = TimeSpan.Parse("13:30:00"), EndTime = TimeSpan.Parse("19:30:00"), DoctorId = 4 },
                new DoctorAvailability(20) { Day = "Friday", StartTime = TimeSpan.Parse("10:00:00"), EndTime = TimeSpan.Parse("15:00:00"), DoctorId = 4 },

                new DoctorAvailability(21) { Day = "Monday", StartTime = TimeSpan.Parse("09:30:00"), EndTime = TimeSpan.Parse("16:30:00"), DoctorId = 5 },
                new DoctorAvailability(22) { Day = "Tuesday", StartTime = TimeSpan.Parse("10:00:00"), EndTime = TimeSpan.Parse("18:00:00"), DoctorId = 5 },
                new DoctorAvailability(23) { Day = "Wednesday", StartTime = TimeSpan.Parse("08:00:00"), EndTime = TimeSpan.Parse("14:00:00"), DoctorId = 5 },
                new DoctorAvailability(24) { Day = "Thursday", StartTime = TimeSpan.Parse("12:30:00"), EndTime = TimeSpan.Parse("17:30:00"), DoctorId = 5 },
                new DoctorAvailability(25) { Day = "Friday", StartTime = TimeSpan.Parse("09:15:00"), EndTime = TimeSpan.Parse("14:15:00"), DoctorId = 5 },

                new DoctorAvailability(26) { Day = "Monday", StartTime = TimeSpan.Parse("08:30:00"), EndTime = TimeSpan.Parse("17:30:00"), DoctorId = 6 },
                new DoctorAvailability(27) { Day = "Tuesday", StartTime = TimeSpan.Parse("09:15:00"), EndTime = TimeSpan.Parse("15:15:00"), DoctorId = 6 },
                new DoctorAvailability(28) { Day = "Wednesday", StartTime = TimeSpan.Parse("10:45:00"), EndTime = TimeSpan.Parse("16:45:00"), DoctorId = 6 },
                new DoctorAvailability(29) { Day = "Thursday", StartTime = TimeSpan.Parse("13:00:00"), EndTime = TimeSpan.Parse("19:00:00"), DoctorId = 6 },
                new DoctorAvailability(30) { Day = "Friday", StartTime = TimeSpan.Parse("08:30:00"), EndTime = TimeSpan.Parse("14:30:00"), DoctorId = 6 }
            };

            await _availabilityRepository.InsertManyAsync(doctorAvailabilities);
        }
    }
}
