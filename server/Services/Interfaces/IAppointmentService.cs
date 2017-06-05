using server.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace server.Services.Interfaces
{
    public interface IAppointmentService
    {
        List<NameDto> GetPurposes();
        void Create(AppointmentDto appointment, string userEmail, string role);
        void Cancel(AppointmentCancellationDto appointmentCancelation);
        void Approve(int id, string role);
    }
}
