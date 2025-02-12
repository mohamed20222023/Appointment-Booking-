using Appointment.Booking.Doctors;
using Appointment.Booking.Dtos;
using AutoMapper;

namespace Appointment.Booking.MappingProfiles;

public class DoctorProfile : Profile
{
    public DoctorProfile()
    {
        CreateMap<Doctor, DoctorDto>();
    }
}