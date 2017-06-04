using server.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services.Interfaces
{
    public interface IPhysicianService
    {
        List<NameDto> GetNames();
    }
}
