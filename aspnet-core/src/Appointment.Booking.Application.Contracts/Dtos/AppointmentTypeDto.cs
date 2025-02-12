using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Booking.Dtos;


public class AppointmentTypeDto
{
    public int Id { get; set; }
    public string TypeName { get; set; }
}

public class CreateAppointmentTypeDto
{
    public string TypeName { get; set; }
}

public class UpdateAppointmentTypeDto
{
    public string TypeName { get; set; }
}