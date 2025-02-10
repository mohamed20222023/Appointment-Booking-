using Microsoft.Extensions.Localization;
using Appointment.Booking.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Appointment.Booking;

[Dependency(ReplaceServices = true)]
public class BookingBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<BookingResource> _localizer;

    public BookingBrandingProvider(IStringLocalizer<BookingResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
