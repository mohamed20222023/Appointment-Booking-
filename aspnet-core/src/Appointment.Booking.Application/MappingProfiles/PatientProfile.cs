using Appointment.Booking.Dtos;
using Appointment.Booking.Patients;
using AutoMapper;

namespace Appointment.Booking.MappingProfiles;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<Patient, PatientDto>();
    }
}