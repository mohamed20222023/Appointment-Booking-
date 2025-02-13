using Appointment.Booking.Appointments;
using Appointment.Booking.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Appointment.Booking.Data.Seeding;

public class AppointmentDataSeeder : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<AppointmentEntity, int> _appointmentRepository;

    public AppointmentDataSeeder(IRepository<AppointmentEntity, int> appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (!await _appointmentRepository.AnyAsync())
        {
            var appointments = new List<AppointmentEntity>();
            var random = new Random();
            int idCounter = 1;

            for (int doctorId = 1; doctorId <= 10; doctorId++)
            {
                for (int i = 1; i <= 5; i++)
                {
                    int patientId = doctorId;
                    var appointmentDate = DateTime.UtcNow.AddDays(random.Next(1, 30));
                    var status = (AppointmentStatus)random.Next(1, 4);
                    int appointmentTypeId = (i % 2 == 0) ? 1 : 2;

                    appointments.Add(new AppointmentEntity(idCounter++)
                    {
                        AppointmentDate = appointmentDate,
                        Status = status,
                        PatientId = patientId,
                        DoctorId = doctorId,
                        AppointmentTypeId = appointmentTypeId
                    });
                }
            }

            await _appointmentRepository.InsertManyAsync(appointments);
        }
    }
}

