using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos
{
    public class AppointmentDto
    {
        public int PatientId { get; set; }
        public int PhysicianId { get; set; }
        public DateTime DateAndTime { get; set; }
        public int PurposeId { get; set; }
    }
}
