using Appointment.Booking.Appointments;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Appointment.Booking.Configurations;

public class AppointmentTypeConfiguration : IEntityTypeConfiguration<AppointmentType>
{
    public void Configure(EntityTypeBuilder<AppointmentType> builder)
    {
        builder.ConfigureByConvention();

        builder.Property(a => a.Id).ValueGeneratedNever();
        builder.Property(at => at.TypeName).IsRequired().HasMaxLength(BookingConsts.MaxLenthText);
        builder.HasMany(at => at.Appointments) .WithOne(a => a.AppointmentType).HasForeignKey(a => a.AppointmentTypeId);
    }
}