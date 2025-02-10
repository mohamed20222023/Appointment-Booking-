using Appointment.Booking.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Appointment.Booking.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BookingController : AbpControllerBase
{
    protected BookingController()
    {
        LocalizationResource = typeof(BookingResource);
    }
}
