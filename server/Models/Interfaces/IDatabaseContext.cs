using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models.Interfaces
{
    public interface IDatabaseContext
    {
        DbSet<Appointment> Appointment { get; set; }
        DbSet<AppointmentPurpose> AppointmentPurpose { get; set; }
        DbSet<Patient> Patient { get; set; }
        DbSet<Physician> Physician { get; set; }
    }
}
