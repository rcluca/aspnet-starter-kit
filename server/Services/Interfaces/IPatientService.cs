﻿using server.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services.Interfaces
{
    public interface IPatientService
    {
        PatientProfileDto GetProfile(string patientEmail);
        PatientProfileDto GetProfile(int patientId, string physicianEmail);
        List<NameDto> GetNames();
    }
}
