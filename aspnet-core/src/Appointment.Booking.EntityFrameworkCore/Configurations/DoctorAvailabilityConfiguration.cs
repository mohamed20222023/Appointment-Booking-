using Appointment.Booking.Doctors;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Appointment.Booking.Configurations;

public class DoctorAvailabilityConfiguration : IEntityTypeConfiguration<DoctorAvailability>
{
    public void Configure(EntityTypeBuilder<DoctorAvailability> builder)
    {
        builder.ConfigureByConvention();

        builder.Property(a => a.Id).ValueGeneratedNever();
        builder.Property(da => da.Day).IsRequired();
        builder.Property(da => da.StartTime) .IsRequired();
        builder.Property(da => da.EndTime) .IsRequired();
        builder.HasOne(da => da.Doctor) .WithMany(d => d.Availability).HasForeignKey(da => da.DoctorId);
    }
}