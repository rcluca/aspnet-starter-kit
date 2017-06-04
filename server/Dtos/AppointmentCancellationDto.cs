using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos
{
    public class AppointmentCancellationDto
    {
        public int Id { get; set; }

        [Required]
        public string CancellationReason { get; set; }
    }
}
