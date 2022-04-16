namespace Web.Models
{
    public class Enums
    {
        // To know the role of an person
        public enum RoleType
        {
            Admin = 1,
            Client = 2
        }

        // To know the payment of an bill
        public enum PaymentType
        {
            Cash = 1,
            Debit = 2,
            Credit = 3
        }

        //Types of api response messages
        public enum MessageType
        {
            None = 0,
            Success = 1,
            Error = 2
        }

    }
}
