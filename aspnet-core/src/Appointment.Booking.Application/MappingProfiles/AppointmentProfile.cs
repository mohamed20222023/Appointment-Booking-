using Appointment.Booking.Appointments;
using Appointment.Booking.Dtos;
using AutoMapper;
using System;
using System.Linq;

namespace Appointment.Booking.MappingProfiles;

public class AppointmentProfile : Profile
{
    public AppointmentProfile()
    {
        CreateMap<CreateAppointmentDto, AppointmentEntity>();
        CreateMap<UpdateAppointmentDto, AppointmentEntity>();

        CreateMap<AppointmentEntity, AppointmentDto>()
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.Name))
            .ForMember(dest => dest.AppointmentType, opt => opt.MapFrom(src => src.AppointmentType.TypeName))
            .ForMember(dest => dest.PatientFullName, opt => opt.MapFrom(src => src.Patient.FullName))
            .ForMember(dest => dest.StatusValue, opt => opt.MapFrom(src => src.Status.ToString()));

        CreateMap<AppointmentEntity, AppointmentWithDoctorPatientDto>()
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.Name))
            .ForMember(dest => dest.AppointmentType, opt => opt.MapFrom(src => src.AppointmentType.TypeName))
            .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName))
            .ForMember(dest => dest.StatusValue, opt => opt.MapFrom(src => src.Status.ToString()));

        CreateMap<IGrouping<string, AppointmentEntity>, AppointmentGroupedByDoctorDto>()
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Key))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.First().Status))
            .ForMember(dest => dest.StatusValue, opt => opt.MapFrom(src => src.First().Status.ToString()))
            .ForMember(dest => dest.AppointmentCount, opt => opt.MapFrom(src => src.Count()));

        CreateMap<AppointmentEntity, AppointmentWithDateRangeDto>()
            .ForMember(dest => dest.PatientTenantId, opt => opt.MapFrom(src => src.Patient.TenantId))
            .ForMember(dest => dest.StatusValue, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName));

        CreateMap<IGrouping<string, AppointmentEntity>, PopularAppointmentTypeDto>()
            .ForMember(dest => dest.AppointmentType, opt => opt.MapFrom(src => src.Key))
            .ForMember(dest => dest.AppointmentCount, opt => opt.MapFrom(src => src.Count()));
    }
}