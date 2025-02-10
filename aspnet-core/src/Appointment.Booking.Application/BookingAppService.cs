using System;
using System.Collections.Generic;
using System.Text;
using Appointment.Booking.Localization;
using Volo.Abp.Application.Services;

namespace Appointment.Booking;

/* Inherit your application services from this class.
 */
public abstract class BookingAppService : ApplicationService
{
    protected BookingAppService()
    {
        LocalizationResource = typeof(BookingResource);
    }
}
