using Domain.Dtos;
using Domain.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPersonServices
    {
        BaseResponse<Login> VefirySession(LoginRequest loginRequest);
    }
}
