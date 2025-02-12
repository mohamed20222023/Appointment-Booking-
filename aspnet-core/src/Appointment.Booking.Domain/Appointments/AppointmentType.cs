using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Appointment.Booking.Appointments;


[Table("AppointmentTypes", Schema = "booking.lkp")]
public class AppointmentType : Entity<int> , IMultiTenant
{
    public AppointmentType(int id) : base(id) { }


    public string TypeName { get; set; }
    public Guid? TenantId { get; set; }

    public ICollection<AppointmentEntity> Appointments { get; set; } = new List<AppointmentEntity>();
}