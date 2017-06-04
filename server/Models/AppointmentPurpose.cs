using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class AppointmentPurpose
    {
        public int Id { get; set; }

        [Required]
        [StringLength(63)]
        public string Purpose { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
