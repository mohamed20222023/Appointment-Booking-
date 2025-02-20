using Appointment.Booking.Common;
using Appointment.Booking.Patients.Dto;
using Appointment.Booking.Patients.IService;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace Appointment.Booking.Patients;


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
        return ObjectMapper.Map<List<Patient>, List<PatientDto>>(Patients);
    }

    public async Task<List<PatientLookupDto>> GetAllPatientsLookupsAsync()
    {
        var patients = await _PatientRepository.GetAllPatientsLookupsAsync();

        return patients.Select(p => new PatientLookupDto
        {
            Id = p.Id,
            Name = p.FullName
        }).ToList();
    }


}
