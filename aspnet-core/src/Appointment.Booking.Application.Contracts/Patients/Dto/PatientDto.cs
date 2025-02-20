namespace Appointment.Booking.Patients.Dto;


public class PatientDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}



public class PatientLookupDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}



