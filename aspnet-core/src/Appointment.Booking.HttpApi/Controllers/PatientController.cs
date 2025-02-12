using Appointment.Booking.Dtos;
using Appointment.Booking.IService;
using Appointment.Booking.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Appointment.Booking.Controllers;


[Route("api/patients")]
public class PatientController : AbpControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
        LocalizationResource = typeof(BookingResource);
    }

    [HttpGet]
    [Route("all")]
    public async Task<List<PatientDto>> GetAllPatientsAsync()
    => await _patientService.GetAllPatientsAsync();
    
}
