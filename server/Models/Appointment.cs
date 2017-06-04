using server.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int PhysicianId { get; set; }
        public DateTime DateAndTime { get; set; }
        public int PurposeId { get; set; }
        public DateTime CreatedDateTime { get; set; }

        [Required]
        public string CreatedBy { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCanceled { get; set; }
        public string CancelationReason { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Physician Physician { get; set; }
        public virtual AppointmentPurpose Purpose { get; set; }
    }
}
