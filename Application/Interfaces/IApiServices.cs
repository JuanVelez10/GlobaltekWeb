using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApiServices
    {
        string ApiPost(string json, string url, string token = null);
        string ApiPut(string json, string url, string token = null);
        string ApiGet(string url, string token = null);

    }
}
