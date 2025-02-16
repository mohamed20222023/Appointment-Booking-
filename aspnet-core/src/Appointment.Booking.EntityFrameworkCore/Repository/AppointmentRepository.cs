using Appointment.Booking.Appointments;
using Appointment.Booking.Common;
using Appointment.Booking.EntityFrameworkCore;
using Appointment.Booking.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Appointment.Booking.Repository;

public class AppointmentRepository : EfCoreRepository<BookingDbContext, AppointmentEntity, int>, IAppointmentRepository
{
    public AppointmentRepository(IDbContextProvider<BookingDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }


    public async Task<bool> AddAppointmentAsync(AppointmentEntity appointment)
    {
        try
        {
            var dbContext = await GetDbContextAsync();

            var lastAppointment = await dbContext.Appointments.OrderByDescending(a => a.Id).FirstOrDefaultAsync();
            int newAppointmentId = (lastAppointment?.Id ?? 0) + 1;

            var newAppointment = new AppointmentEntity(newAppointmentId)
            {
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                AppointmentTypeId = appointment.AppointmentTypeId
            };

            await dbContext.Appointments.AddAsync(newAppointment);
            await dbContext.SaveChangesAsync();

            return true; 
        }
        catch (Exception ex)
        {
            return false;
        }
    }



    public async Task<IQueryable<AppointmentEntity>> GetAppointmentsForPatientAsync( int patientId)
    {
        var dbContext = await GetDbContextAsync();
        return dbContext.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Doctor)
            .Include(a => a.AppointmentType)
            .WhereIf(patientId > 0, a => a.PatientId == patientId)
            .AsQueryable();
    }

    public async Task<IQueryable<AppointmentEntity>> GetAppointmentsForDoctorAsync(int doctorId)
    {
        var dbContext = await GetDbContextAsync();
        return dbContext.Appointments
            .Include(a => a.Doctor)
            .Include(a => a.Patient)
            .Include(a => a.AppointmentType)
            .WhereIf(doctorId > 0, a => a.DoctorId == doctorId)
            .AsQueryable();
    }

    public async Task<IQueryable<AppointmentEntity>> GetUpcomingAppointmentsForPatientAsync(int patientId)
    {
        var dbContext = await GetDbContextAsync();
        return dbContext.Appointments
            .Include(a => a.Doctor)
            .Include(a => a.AppointmentType)
            .Include(a => a.Patient)
            .WhereIf(patientId > 0, a => a.PatientId == patientId)
            .Where(a => a.AppointmentDate > DateTime.UtcNow)
            .AsQueryable();
    }

    public async Task<IQueryable<AppointmentGroupedByDoctor>> GetAppointmentCountsGroupedByDoctorAndStatusAsync()
    {
        var dbContext = await GetDbContextAsync();

        return dbContext.Appointments
            .Include(a => a.Doctor)
            .GroupBy(a => new { a.Doctor.Name, a.Status })
            .Select(g => new AppointmentGroupedByDoctor
            {
                DoctorName = g.Key.Name,
                Status = g.Key.Status,
                AppointmentCount = g.Count()
            });
    }




    public async Task<IQueryable<AppointmentEntity>> GetAppointmentsForDoctorWithinDateRangeAsync(int doctorId, DateTime? startDate, DateTime? endDate)
    {
        var dbContext = await GetDbContextAsync();

        return dbContext.Appointments
            .Include(a => a.Patient)
            .Where(a => a.DoctorId == doctorId)
            .Where(a => !startDate.HasValue || !endDate.HasValue || (a.AppointmentDate >= startDate.Value && a.AppointmentDate <= endDate.Value)) // Return all if dates are null
            .AsQueryable();
    }


    public async Task<IQueryable<PopularAppointmentType>> GetPopularAppointmentTypesForDoctorAsync(int doctorId)
    {
        var dbContext = await GetDbContextAsync();

        return dbContext.Appointments
            .Include(a => a.AppointmentType)
            .WhereIf(doctorId > 0, a => a.DoctorId == doctorId)
            .GroupBy(a => a.AppointmentType.TypeName)
            .Select(g => new PopularAppointmentType
            {
                AppointmentType = g.Key,
                AppointmentCount = g.Count()
            });
    }

    public async Task<Dictionary<string, object>> GetAppointmentLookupsAsync()
    {
        var dbContext = await GetDbContextAsync();

        var appointmentTypes = await dbContext.AppointmentTypes
            .Select(a => new { Id = a.Id, Name = a.TypeName })
            .ToListAsync();

        var appointmentStatuses = Enum.GetValues(typeof(AppointmentStatus))
            .Cast<AppointmentStatus>()
            .Select(status => new { Id = (int)status, Name = status.ToString() })
            .ToList();

        // Combine both in a dictionary
        return new Dictionary<string, object>
    {
        { "AppointmentTypes", appointmentTypes },
        { "AppointmentStatuses", appointmentStatuses }
    };
    }


}