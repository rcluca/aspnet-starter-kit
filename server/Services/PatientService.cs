using Microsoft.EntityFrameworkCore;
using server.Dtos;
using server.Models;
using server.Models.Interfaces;
using server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public class PatientService : IPatientService
    {
        public PatientService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public PatientProfileDto GetProfile(string patientEmail)
        {
            var patient = _databaseContext.Patient.SingleOrDefault(p => p.Email == patientEmail);

            if (patient == null)
                throw new ArgumentException($"No patient could be found with email '{patientEmail}'.");

            return GetProfile(patient);
        }

        public PatientProfileDto GetProfile(int patientId, string physicianEmail)
        {
            var patient = _databaseContext.Patient.SingleOrDefault(p => p.Id == patientId);

            if (patient == null)
                throw new ArgumentException($"No patient could be found with id '{patientId}'.");

            var physician = _databaseContext.Physician.SingleOrDefault(p => p.Email == physicianEmail);

            if (physician == null)
                throw new ArgumentException($"No physician could be found with email '{physicianEmail}'.");

            return GetProfile(patient, physician);
        }

        private PatientProfileDto GetProfile(Patient patient, Physician physician = null)
        {
            var patientProfileDto = new PatientProfileDto
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
                Address1 = patient.Address1,
                Address2 = patient.Address2,
                City = patient.City,
                State = patient.State,
                Zip = patient.Zip
            };

            List<Appointment> appointments;
            
            if (physician == null)
                appointments = _databaseContext.Appointment
                                    .Where(w => w.PatientId == patient.Id)
                                    .Include(i => i.Purpose)
                                    .Include(i => i.Physician)
                                    .ToList();
            else
                appointments = _databaseContext.Appointment
                                                    .Where(w => w.PatientId == patient.Id && w.PhysicianId == physician.Id)
                                                    .Include(i => i.Purpose)
                                                    .Include(i => i.Physician)
                                                    .ToList();

            if (appointments != null && appointments.Count > 0)
            {
                patientProfileDto.Appointments = new List<PatientProfileDto.AppointmentDto>();
                foreach (var appointment in appointments)
                {
                    patientProfileDto.Appointments.Add(new PatientProfileDto.AppointmentDto
                    {
                        Id = appointment.Id,
                        Physician = appointment.Physician.FirstName + " " + appointment.Physician.LastName,
                        DateAndTime = appointment.DateAndTime,
                        Purpose = appointment.Purpose.Purpose,
                        CreatedDateTime = appointment.CreatedDateTime,
                        CreatedBy = appointment.CreatedBy,
                        IsApproved = appointment.IsApproved,
                        IsCanceled = appointment.IsCanceled,
                        CancelationReason = appointment.CancellationReason
                    });
                }
            }

            return patientProfileDto;
        }

        public List<NameDto> GetNames()
        {
            var names = _databaseContext.Patient.Select(s => new NameDto
            {
                Id = s.Id,
                Name = s.FirstName + " " + s.LastName
            }).ToList();

            return names;
        }

        private IDatabaseContext _databaseContext;
    }
}
