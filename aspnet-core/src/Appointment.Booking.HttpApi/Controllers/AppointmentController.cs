using Appointment.Booking.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Volo.Abp.AspNetCore.Mvc;
using Appointment.Booking.Appointment.Dto;
using Appointment.Booking.Appointment.IService;

namespace Appointment.Booking.Controllers;

[Route("api/appointments")]
public class AppointmentController : AbpControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
        LocalizationResource = typeof(BookingResource);
    }

    [HttpPost]
    [Route("add")]
    public async Task<bool> AddAppointmentAsync([FromBody] AddAppointmentDto request)
    => await _appointmentService.AddAppointmentAsync(request);


    [HttpGet]
    [Route("appointments")]
    public async Task<List<AppointmentDto>> GetAppointmentsAsync()
    => await _appointmentService.GetAllAppointmentsAsync();
    
    [HttpGet]
    [Route("patient/{patientId}")]
    public async Task<List<AppointmentDto>> GetAppointmentsForPatientAsync(int patientId)
    => await _appointmentService.GetAppointmentsForPatientAsync(patientId);
    

    [HttpGet]
    [Route("doctor/{doctorId}")]
    public async Task<List<AppointmentDto>> GetAppointmentsForDoctorAsync(int doctorId)
    => await _appointmentService.GetAppointmentsForDoctorAsync(doctorId);
    

    [HttpGet]
    [Route("patient/upcoming/{patientId}")]
    public async Task<List<AppointmentWithDoctorPatientDto>> GetUpcomingAppointmentsForPatientAsync( int patientId)
    => await _appointmentService.GetUpcomingAppointmentsForPatientAsync( patientId);
    

    [HttpGet]
    [Route("grouped-by-doctor")]
    public async Task<List<AppointmentGroupedByDoctorDto>> GetAppointmentCountsGroupedByDoctorAndStatusAsync()
    => await _appointmentService.GetAppointmentCountsGroupedByDoctorAndStatusAsync();
    

    [HttpGet]
    [Route("doctor/{doctorId}/date-range")]
    public async Task<List<AppointmentWithDateRangeDto>> GetAppointmentsForDoctorWithinDateRangeAsync(int doctorId, [FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null)
    => await _appointmentService.GetAppointmentsForDoctorWithinDateRangeAsync(doctorId, startDate, endDate);
    

    [HttpGet]
    [Route("doctor/{doctorId}/popular-appointment-types")]
    public async Task<List<PopularAppointmentTypeDto>> GetPopularAppointmentTypesForDoctorAsync(int doctorId)
    => await _appointmentService.GetPopularAppointmentTypesForDoctorAsync(doctorId);


    [HttpGet]
    [Route("lookup")]
    public async Task<AppointmentLookupsDto> GetAppointmentLookupsAsync()
    => await _appointmentService.GetAppointmentLookupsAsync();


}
