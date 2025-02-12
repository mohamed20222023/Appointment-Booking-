using System;

namespace Appointment.Booking.Dtos;

public class DoctorAvailabilityDto
{
    public int DoctorId { get; set; }
    public string Day { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}

public class CreateDoctorAvailabilityDto
{
    public int DoctorId { get; set; }
    public string Day { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}

public class UpdateDoctorAvailabilityDto
{
    public string Day { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}