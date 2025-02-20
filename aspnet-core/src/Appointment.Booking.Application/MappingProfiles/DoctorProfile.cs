using Appointment.Booking.Doctors;
using Appointment.Booking.Doctors.Dto;
using AutoMapper;

namespace Appointment.Booking.MappingProfiles;

public class DoctorProfile : Profile
{
    public DoctorProfile()
    {
        CreateMap<Doctor, DoctorDto>();
    }
}