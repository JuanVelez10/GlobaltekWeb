using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApiServices
    {
        string ApiPost(string json, string service, string token = null);
        string ApiPut(string json, string service, string token = null);
        string ApiGet(string service, string token = null);
        string ApiDelete(string service, string token = null);
    }
}
