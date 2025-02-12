namespace Appointment.Booking.Common;


public class AppointmentGroupedByDoctor
{
    public string DoctorName { get; set; }
    public AppointmentStatus Status { get; set; }
    public int AppointmentCount { get; set; }
}
