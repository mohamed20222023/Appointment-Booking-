using System;

namespace Appointment.Booking.Dtos;

public class PaymentDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; }
    public string PaymentStatus { get; set; }
    public DateTime PaymentDate { get; set; }
    public int AppointmentId { get; set; }
}

public class CreatePaymentDto
{
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; }
    public string PaymentStatus { get; set; }
    public DateTime PaymentDate { get; set; }
    public int AppointmentId { get; set; }
}

public class UpdatePaymentDto
{
    public string PaymentStatus { get; set; }
}
