using Appointment.Booking.Payments;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Appointment.Booking.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ConfigureByConvention();

        builder.Property(a => a.Id).ValueGeneratedNever();
        builder.Property(p => p.Amount).IsRequired();
        builder.Property(p => p.PaymentMethod).IsRequired();
        builder.Property(p => p.PaymentStatus).IsRequired();
        builder.Property(p => p.PaymentDate).IsRequired();
        builder.HasOne(p => p.Appointment).WithOne(a => a.Payment).HasForeignKey<Payment>(p => p.AppointmentId);

    }
}