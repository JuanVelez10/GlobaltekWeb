using Domain.Dtos;
using Domain.Entities;
using Domain.References;

namespace Application.Interfaces
{
    public interface IPersonServices
    {
        List<Person> GetAll(string token);
        BaseResponse<Login> VefirySession(LoginRequest loginRequest);
    }
}
