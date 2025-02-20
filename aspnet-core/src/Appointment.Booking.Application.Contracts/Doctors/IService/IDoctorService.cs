using Appointment.Booking.Doctors.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.Booking.Doctors.IService;


public interface IDoctorService
{
    Task<List<DoctorDto>> GetAllDoctorsAsync();
    Task<List<DoctorLookupDto>> GetAllDoctorsLookupsAsync();
    Task<List<DoctorAvailabilityDto>> GetDoctorAvailabilityAsync(int doctorId);
}