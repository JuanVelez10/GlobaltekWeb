using Web.Models;
using Web.Services;

namespace Web.Manager
{
    public class BillManager
    {
        public string VefirySession(LoginRequest login)
        {
            var response = new BillServices().Login(login);

            if (response == null) return string.Empty;
            if (response.Data == null) return string.Empty;

            return response.Data.Token;
            
        }

        public List<BillBasic> GetAllBill(string token)
        {
            List<BillBasic> billBasics = new List<BillBasic>();

            billBasics = new BillServices().GetAllBill(token);

            return billBasics;

        }



    }
}
