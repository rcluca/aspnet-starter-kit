using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos
{
    public class PatientProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public List<AppointmentDto> Appointments { get; set; }

        public class AppointmentDto
        {
            public int Id { get; set; }
            public string Physician { get; set; }
            public DateTime DateAndTime { get; set; }
            public string Purpose { get; set; }
            public DateTime CreatedDateTime { get; set; }
            public string CreatedBy { get; set; }
            public bool IsApproved { get; set; }
            public bool IsCanceled { get; set; }
            public string CancellationReason { get; set; }
        }
    }
}
