using static Web.Models.Enums;

namespace Web.Models
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            ResponseTime = DateTime.Now;
            Message = "";
            Code = 0;
            MessageType = MessageType.None;
        }

        public DateTime ResponseTime { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public MessageType MessageType { get; set; }
        public T Data { get; set; }
    }
}
