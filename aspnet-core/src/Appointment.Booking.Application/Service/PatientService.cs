using Appointment.Booking.Common;
using Appointment.Booking.Dtos;
using Appointment.Booking.IRepository;
using Appointment.Booking.IService;
using Appointment.Booking.Patients;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace Appointment.Booking.Service;


[RemoteService(false)]
public class PatientService : BaseAppService, IPatientService
{
    private readonly IPatientRepository _PatientRepository;

    public PatientService(IPatientRepository PatientRepository)
    {
        _PatientRepository = PatientRepository;
    }

    public async Task<List<PatientDto>> GetAllPatientsAsync()
    {
        var queryablePatients = await _PatientRepository.GetAllPatientsAsync();
        var Patients = await queryablePatients.ToListAsync();
        return ObjectMapper.Map< List<Patient> , List<PatientDto>>(Patients);
    }

    public async Task<List<object>> GetAllPatientsLookupsAsync()
    {
        return await _PatientRepository.GetAllPatientsLookupsAsync();
    }
}
