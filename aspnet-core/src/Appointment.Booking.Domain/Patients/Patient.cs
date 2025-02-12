using Appointment.Booking.Appointments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Appointment.Booking.Patients;


[Table("Patients", Schema = "booking")]
public class Patient : FullAuditedEntity<int> , IMultiTenant
{
    public Patient(int id): base(id) {}
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Guid? TenantId { get; set; }

    public ICollection<AppointmentEntity> Appointments { get; set; } = new List<AppointmentEntity>();
}