using Appointment.Booking.Patients.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.Booking.Patients.IService;


public interface IPatientService
{
    Task<List<PatientDto>> GetAllPatientsAsync();
    Task<List<PatientLookupDto>> GetAllPatientsLookupsAsync();
}