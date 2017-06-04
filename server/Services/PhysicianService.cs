using server.Dtos;
using server.Models.Interfaces;
using server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public class PhysicianService : IPhysicianService
    {
        public PhysicianService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<PatientDto> GetPatients()
        {
            var patients = _databaseContext.Patient.Select(patient => new PatientDto
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
                City = patient.City,
                State = patient.State
            }).ToList();

            return patients;
        }

        public List<NameDto> GetNames()
        {
            var names = _databaseContext.Physician.Select(s => new NameDto
            {
                Id = s.Id,
                Name = s.FirstName + " " + s.LastName
            }).ToList();

            return names;
        }

        private IDatabaseContext _databaseContext;
    }
}
