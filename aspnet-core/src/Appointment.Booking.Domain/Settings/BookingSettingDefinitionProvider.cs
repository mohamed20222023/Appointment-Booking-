using Volo.Abp.Settings;

namespace Appointment.Booking.Settings;

public class BookingSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BookingSettings.MySetting1));
    }
}
