using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;


namespace Appointment.Booking.Doctors;



[Table("DoctorAvailabilities", Schema = "booking")]
public class DoctorAvailability : Entity<int> , IMultiTenant
{
    public DoctorAvailability(int id) : base(id) { }
    public string Day { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int DoctorId { get; set; }
    public Guid? TenantId { get; set; }


    public Doctor Doctor { get; set; }
}
