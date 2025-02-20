using Appointment.Booking.Common;
using Appointment.Booking.Doctors.Dto;
using Appointment.Booking.Doctors.IService;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace Appointment.Booking.Doctors;


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
        return ObjectMapper.Map<List<Doctor>, List<DoctorDto>>(doctors);
    }

    public async Task<List<DoctorLookupDto>> GetAllDoctorsLookupsAsync()
    {
        var doctors = await _doctorRepository.GetAllDoctorsLookupsAsync();

        return doctors.Select(d => new DoctorLookupDto
        {
            Id = d.Id,
            Name = d.Name
        }).ToList();
    }


    public async Task<List<DoctorAvailabilityDto>> GetDoctorAvailabilityAsync(int doctorId)
    {
        var availabilityList = await _doctorRepository.GetDoctorAvailabilityAsync(doctorId);

        return availabilityList.Select(da => new DoctorAvailabilityDto
        {
            Name = da.Doctor.Name,
            Day = da.Day,
            StartTime = da.StartTime,
            EndTime = da.EndTime
        }).ToList();
    }

}
