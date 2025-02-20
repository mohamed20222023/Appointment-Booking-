using Appointment.Booking.Common;
using System;
using System.Collections.Generic;

namespace Appointment.Booking.Appointment.Dto;

public class AddAppointmentDto
{
    public DateTime AppointmentDate { get; set; }
    public AppointmentStatus Status { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public int AppointmentTypeId { get; set; }
}

public class AppointmentDto
{
    public int Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string StatusValue { get; set; }
    public AppointmentStatus Status { get; set; }
    public string PatientFullName { get; set; }
    public string DoctorName { get; set; }
    public string AppointmentType { get; set; }
}

public class AppointmentWithDoctorPatientDto
{
    public int Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string StatusValue { get; set; }
    public AppointmentStatus Status { get; set; }
    public string DoctorName { get; set; }
    public string AppointmentType { get; set; }
    public string PatientName { get; set; }
}

public class AppointmentGroupedByDoctorDto
{
    public string DoctorName { get; set; }
    public string StatusValue { get; set; }
    public AppointmentStatus Status { get; set; }
    public int AppointmentCount { get; set; }
}

public class AppointmentWithDateRangeDto
{
    public int Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public int PatientTenantId { get; set; }
    public int PatientId { get; set; }
    public string PatientName { get; set; }
    public string StatusValue { get; set; }
    public AppointmentStatus Status { get; set; }
}

public class PopularAppointmentTypeDto
{
    public string AppointmentType { get; set; }
    public int AppointmentCount { get; set; }
}


public class AppointmentLookupsDto
{
    public List<AppointmentTypeLookupDto> AppointmentTypes { get; set; }
    public List<AppointmentStatusLookupDto> AppointmentStatuses { get; set; }
}

public class AppointmentTypeLookupDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class AppointmentStatusLookupDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
