using Appointment.Booking.Dtos;
using Appointment.Booking.IService;
using Appointment.Booking.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Appointment.Booking.Controllers;

[Route("api/doctors")]
public class DoctorController : AbpControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
        LocalizationResource = typeof(BookingResource);
    }

    [HttpGet]
    [Route("all")]
    public async Task<List<DoctorDto>> GetAllDoctorsAsync()
    => await _doctorService.GetAllDoctorsAsync();
    
}
