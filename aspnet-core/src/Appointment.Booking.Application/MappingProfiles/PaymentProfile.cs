using Appointment.Booking.Dtos;
using Appointment.Booking.Payments;
using AutoMapper;

namespace Appointment.Booking.MappingProfiles;

public class PaymentProfile : Profile
{
    public PaymentProfile()
    {
        CreateMap<Payment, PaymentDto>();
    }
}