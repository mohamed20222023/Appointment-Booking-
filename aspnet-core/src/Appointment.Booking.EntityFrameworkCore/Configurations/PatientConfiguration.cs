using Appointment.Booking.Patients;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Appointment.Booking.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {

        builder.ConfigureByConvention();

        builder.Property(a => a.Id).ValueGeneratedNever();
        builder.Property(p => p.FullName).IsRequired().HasMaxLength(BookingConsts.MaxLenthText);
        builder.Property(p => p.Email).IsRequired();
        builder.Property(p => p.PhoneNumber).IsRequired();
        builder.HasMany(p => p.Appointments).WithOne(a => a.Patient).HasForeignKey(a => a.PatientId);
    }
}