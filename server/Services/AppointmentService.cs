using server.Constants;
using server.Dtos;
using server.Enums;
using server.Models;
using server.Models.Interfaces;
using server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace server.Services
{
    public class AppointmentService : IAppointmentService
    {
        public AppointmentService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<NameDto> GetPurposes()
        {
            var purposes = _databaseContext.AppointmentPurpose.Select(s => new NameDto
            {
                Id = s.Id,
                Name = s.Purpose
            }).ToList();

            return purposes;
        }

        public void Create(AppointmentDto appointment, string userEmail, string role)
        {
            if (role == Roles.Patient)
            {
                var patient = _databaseContext.Patient.SingleOrDefault(p => p.Email == userEmail);

                if (patient == null)
                    throw new ArgumentException($"No patient could be found with the email '{userEmail}'.");

                _databaseContext.Appointment.Add(new Appointment
                {
                    PatientId = patient.Id,
                    PhysicianId = appointment.PhysicianId,
                    DateAndTime = appointment.DateAndTime,
                    PurposeId = appointment.PurposeId,
                    CreatedDateTime = DateTime.UtcNow,
                    CreatedBy = CreatedBy.Patient.ToString()
                });
            }
            else
            {
                var physician = _databaseContext.Physician.SingleOrDefault(p => p.Email == userEmail);

                if (physician == null)
                    throw new ArgumentException($"No physician could be found with the email '{userEmail}'.");

                _databaseContext.Appointment.Add(new Appointment
                {
                    PatientId = appointment.PatientId,
                    PhysicianId = physician.Id,
                    DateAndTime = appointment.DateAndTime,
                    PurposeId = appointment.PurposeId,
                    CreatedDateTime = DateTime.UtcNow,
                    CreatedBy = CreatedBy.Physician.ToString()
                });
            }

            _databaseContext.SaveChanges();
        }

        private IDatabaseContext _databaseContext;
    }
}
