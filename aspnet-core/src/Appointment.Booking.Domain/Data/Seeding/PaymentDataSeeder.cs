using Appointment.Booking.Payments;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Appointment.Booking.Data.Seeding;

public class PaymentDataSeeder : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Payment, int> _paymentRepository;

    public PaymentDataSeeder(IRepository<Payment, int> paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (!await _paymentRepository.AnyAsync())
        {
            await _paymentRepository.InsertManyAsync(new[]
            {
                new Payment(1) { Amount = 100.00m, PaymentMethod = "Credit Card", PaymentStatus = "Paid", PaymentDate = DateTime.UtcNow, AppointmentId = 1 },
                new Payment(2) { Amount = 50.00m, PaymentMethod = "Cash", PaymentStatus = "Pending", PaymentDate = DateTime.UtcNow, AppointmentId = 2 },
                new Payment(3) { Amount = 100.00m, PaymentMethod = "Credit Card", PaymentStatus = "Paid", PaymentDate = DateTime.UtcNow, AppointmentId = 3 },
                new Payment(4) { Amount = 50.00m, PaymentMethod = "Cash", PaymentStatus = "Pending", PaymentDate = DateTime.UtcNow, AppointmentId = 4 },
                new Payment(5) { Amount = 100.00m, PaymentMethod = "Credit Card", PaymentStatus = "Paid", PaymentDate = DateTime.UtcNow, AppointmentId = 5 },
                new Payment(6) { Amount = 50.00m, PaymentMethod = "Cash", PaymentStatus = "Pending", PaymentDate = DateTime.UtcNow, AppointmentId = 6 },
                new Payment(7) { Amount = 100.00m, PaymentMethod = "Credit Card", PaymentStatus = "Paid", PaymentDate = DateTime.UtcNow, AppointmentId = 7 },
                new Payment(8) { Amount = 50.00m, PaymentMethod = "Cash", PaymentStatus = "Pending", PaymentDate = DateTime.UtcNow, AppointmentId = 8 },
                new Payment(9) { Amount = 100.00m, PaymentMethod = "Credit Card", PaymentStatus = "Paid", PaymentDate = DateTime.UtcNow, AppointmentId = 9 },
                new Payment(10) { Amount = 50.00m, PaymentMethod = "Cash", PaymentStatus = "Pending", PaymentDate = DateTime.UtcNow, AppointmentId = 10 }
            });
        }
    }
}
