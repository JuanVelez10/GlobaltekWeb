using Domain.Entities;
using Domain.References;

namespace Application.Interfaces
{
    public interface IBillServices
    {
        List<BillBasic> GetAllBill(string token);

    }
}
