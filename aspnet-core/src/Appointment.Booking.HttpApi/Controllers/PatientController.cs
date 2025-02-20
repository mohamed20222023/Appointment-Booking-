using Appointment.Booking.Localization;
using Appointment.Booking.Patients.Dto;
using Appointment.Booking.Patients.IService;
using Microsoft.AspNetCore.Mvc;
using System;
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

    [HttpGet]
    [Route("Lookups")]
    public async Task<List<PatientLookupDto>> GetAllPatientsLookupsAsync()
    => await _patientService.GetAllPatientsLookupsAsync();
    
}
