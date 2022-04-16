using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApiServices
    {
        string ApiPost(string json, string url);
        string ApiGet(string token, string url);

    }
}
