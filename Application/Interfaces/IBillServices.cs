using Domain.Dtos;
using Domain.Entities;
using Domain.References;

namespace Application.Interfaces
{
    public interface IBillServices
    {
        List<BillBasic> GetAllBill(string token);
        BillInfo GetBillInfo(string token, Guid? id);

    }
}
