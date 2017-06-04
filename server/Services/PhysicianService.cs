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
