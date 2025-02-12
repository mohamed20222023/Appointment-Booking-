using Appointment.Booking.Doctors;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Appointment.Booking.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ConfigureByConvention();

        builder.Property(a => a.Id).ValueGeneratedNever();
        builder.Property(d => d.Name).IsRequired().HasMaxLength(BookingConsts.MaxLenthText);
        builder.Property(d => d.Specialization).IsRequired().HasMaxLength(BookingConsts.MaxLenthText);
        builder.Property(d => d.Email).IsRequired();
        builder.Property(d => d.PhoneNumber).IsRequired();
        builder.HasMany(d => d.Appointments) .WithOne(a => a.Doctor) .HasForeignKey(a => a.DoctorId);
        builder.HasMany(d => d.Availability).WithOne(da => da.Doctor).HasForeignKey(da => da.DoctorId);
    }
}