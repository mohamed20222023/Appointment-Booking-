using Appointment.Booking.Payments;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Appointment.Booking.Appointments;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Appointment.Booking.Configurations;

public class AppointmentConfiguration : IEntityTypeConfiguration<AppointmentEntity>
{
    public void Configure(EntityTypeBuilder<AppointmentEntity> builder)
    {
        builder.ConfigureByConvention();

        builder.Property(a => a.Id).ValueGeneratedNever();
        builder.Property(a => a.AppointmentDate).IsRequired();
        builder.Property(a => a.Status).IsRequired();
        builder.HasOne(a => a.Patient).WithMany(p => p.Appointments).HasForeignKey(a => a.PatientId);
        builder.HasOne(a => a.Doctor)  .WithMany(d => d.Appointments) .HasForeignKey(a => a.DoctorId);
        builder.HasOne(a => a.AppointmentType) .WithMany(at => at.Appointments).HasForeignKey(a => a.AppointmentTypeId);
        builder.HasOne(a => a.Payment).WithOne(p => p.Appointment).HasForeignKey<Payment>(p => p.AppointmentId);
    }
}