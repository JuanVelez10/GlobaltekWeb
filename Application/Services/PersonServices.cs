using Application.Interfaces;
using Domain.Dtos;
using Domain.References;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public  class PersonServices: IPersonServices
    {
        private IApiServices apiServices;

        public PersonServices(IApiServices apiServices)
        {
            this.apiServices = apiServices;
        }

        public string VefirySession(LoginRequest loginRequest)
        {
            var response = new BaseResponse<Login>();

            try
            {
                var json = JsonConvert.SerializeObject(loginRequest);
                response = JsonConvert.DeserializeObject<BaseResponse<Login>>(apiServices.ApiPost(json, "Person/Login"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            if (response == null) return string.Empty;
            if (response.Data == null) return string.Empty;
            return response.Data.Token;

        }

    }
}
