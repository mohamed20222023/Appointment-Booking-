using Appointment.Booking.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.Booking.IService;


public interface IPatientService
{
    Task<List<PatientDto>> GetAllPatientsAsync();
    Task<List<object>> GetAllPatientsLookupsAsync();
}