using Appointment.Booking.Common;
using Appointment.Booking.Doctors;
using Appointment.Booking.Dtos;
using Appointment.Booking.IRepository;
using Appointment.Booking.IService;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace Appointment.Booking.Service;


[RemoteService(false)]
public class DoctorService : BaseAppService, IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<List<DoctorDto>> GetAllDoctorsAsync()
    {
        var queryableDoctors = await _doctorRepository.GetAllDoctorsAsync();
        var doctors = await queryableDoctors.ToListAsync();
        return ObjectMapper.Map< List<Doctor> ,List <DoctorDto>>(doctors);
    }

    public async Task<List<object>> GetAllDoctorsLookupsAsync()
    {
        return await _doctorRepository.GetAllDoctorsLookupsAsync();
    }

    public async Task<List<DoctorAvailabilityDto>> GetDoctorAvailabilityAsync(int doctorId)
    {
        var availabilityList = await _doctorRepository.GetDoctorAvailabilityAsync(doctorId);

        return availabilityList.Select(da => new DoctorAvailabilityDto
        {
            Day = da.Day,
            StartTime = da.StartTime,
            EndTime = da.EndTime
        }).ToList();
    }

}
