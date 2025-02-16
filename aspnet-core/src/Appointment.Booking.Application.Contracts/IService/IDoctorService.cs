using Appointment.Booking.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.Booking.IService;


public interface IDoctorService
{
    Task<List<DoctorDto>> GetAllDoctorsAsync();
    Task<List<object>> GetAllDoctorsLookupsAsync();
    Task<List<DoctorAvailabilityDto>> GetDoctorAvailabilityAsync(int doctorId);
}