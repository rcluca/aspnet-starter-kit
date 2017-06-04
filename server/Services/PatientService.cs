using server.Dtos.Account;
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
                throw new ArgumentException($"No patient could be found with the email '{patientEmail}'.");


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
