using Appointment.Booking.Appointments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Appointment.Booking.Doctors;


[Table("Doctors", Schema = "booking")]
public class Doctor : FullAuditedEntity<int> , IMultiTenant
{
    public Doctor(int id) : base(id) { }

    public string Name { get; set; }
    public string Specialization { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Guid? TenantId { get; set; }


    public ICollection<AppointmentEntity> Appointments { get; set; } = new List<AppointmentEntity>();
    public ICollection<DoctorAvailability> Availability { get; set; } = new List<DoctorAvailability>();

}