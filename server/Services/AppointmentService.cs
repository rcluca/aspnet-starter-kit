using server.Dtos.Account;
using server.Models.Interfaces;
using server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private IDatabaseContext _databaseContext;
    }
}
