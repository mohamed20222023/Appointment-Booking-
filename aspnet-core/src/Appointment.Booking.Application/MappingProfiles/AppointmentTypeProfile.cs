using Appointment.Booking.Appointments;
using Appointment.Booking.Dtos;
using AutoMapper;

namespace Appointment.Booking.MappingProfiles;

public class AppointmentTypeProfile : Profile
{
    public AppointmentTypeProfile()
    {
        CreateMap<AppointmentType, AppointmentTypeDto>();
        CreateMap<CreateAppointmentTypeDto, AppointmentType>();
        CreateMap<UpdateAppointmentTypeDto, AppointmentType>();
    }
}