using Domain.Entities;
using Domain.References;

namespace Application.Interfaces
{
    public interface IBillServices
    {
        string VefirySession(LoginRequest loginRequest);
        List<BillBasic> GetAllBill(string token);

    }
}
