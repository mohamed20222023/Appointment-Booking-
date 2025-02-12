using Volo.Abp;

namespace Appointment.Booking.Common;

public class NotFoundException : BusinessException
{
    public NotFoundException(int id) : base(BookingDomainErrorCodes.Not_Found)
    {
        WithData("id", id);
    }
}

