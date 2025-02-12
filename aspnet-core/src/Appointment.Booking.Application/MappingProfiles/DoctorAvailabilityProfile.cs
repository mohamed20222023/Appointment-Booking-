using Appointment.Booking.Doctors;
using Appointment.Booking.Dtos;
using AutoMapper;

namespace Appointment.Booking.MappingProfiles;

public class DoctorAvailabilityProfile : Profile
{
    public DoctorAvailabilityProfile()
    {
        CreateMap<DoctorAvailability, DoctorAvailabilityDto>();
        CreateMap<CreateDoctorAvailabilityDto, DoctorAvailability>();
        CreateMap<UpdateDoctorAvailabilityDto, DoctorAvailability>();
    }
}