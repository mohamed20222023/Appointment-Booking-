using Appointment.Booking.Common;
using Appointment.Booking.Doctors;
using Appointment.Booking.Patients;
using Appointment.Booking.Payments;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Appointment.Booking.Appointments;


[Table("AppointmentEntities", Schema = "booking")]
public class AppointmentEntity : FullAuditedEntity<int> , IMultiTenant
{
    public AppointmentEntity(int id) : base(id) { }

    public DateTime AppointmentDate { get; set; }
    public AppointmentStatus Status { get; set; } 
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public int AppointmentTypeId { get; set; }
    public Guid? TenantId { get; set; }


    public Doctor Doctor { get; set; }
    public Patient Patient { get; set; }
    public Payment Payment { get; set; }
    public AppointmentType AppointmentType { get; set; }
}



