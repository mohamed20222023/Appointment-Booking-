using Appointment.Booking.Patients;
using Appointment.Booking.Patients.Dto;
using AutoMapper;

namespace Appointment.Booking.MappingProfiles;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<Patient, PatientDto>();
    }
}