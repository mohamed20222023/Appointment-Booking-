using System;

namespace Appointment.Booking.Doctors.Dto;


public class DoctorDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}

public class DoctorLookupDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class DoctorAvailabilityDto
{
    public string Name { get; set; }
    public string Day { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
