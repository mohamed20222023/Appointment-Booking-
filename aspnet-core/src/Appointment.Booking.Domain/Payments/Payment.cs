using Appointment.Booking.Appointments;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Appointment.Booking.Payments;


[Table("Payments", Schema = "booking")]
public class Payment : AuditedEntity<int> , IMultiTenant
{
    public Payment(int id) : base(id) {}

    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; }
    public string PaymentStatus { get; set; }
    public DateTime PaymentDate { get; set; }
    public int AppointmentId { get; set; }
    public Guid? TenantId { get; set; }



    public AppointmentEntity Appointment { get; set; }
}
