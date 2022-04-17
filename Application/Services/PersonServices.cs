using Application.Interfaces;
using Domain.Dtos;
using Domain.Entities;
using Domain.References;
using Newtonsoft.Json;
using static Domain.Enums.Enums;

namespace Application.Services
{
    public  class PersonServices: IPersonServices
    {
        private readonly IApiServices apiServices;

        public PersonServices(IApiServices apiServices)
        {
            this.apiServices = apiServices;
        }

        public BaseResponse<Login> VefirySession(LoginRequest loginRequest)
        {
            var response = new BaseResponse<Login>();

            try
            {
                var json = JsonConvert.SerializeObject(loginRequest);
                response = JsonConvert.DeserializeObject<BaseResponse<Login>>(apiServices.ApiPost(json, "Person/Login"));
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.MessageType = MessageType.Error;
                return response;
            }

            return response;

        }

        public List<Person> GetAll(string token)
        {
            return JsonConvert.DeserializeObject<List<Person>>(apiServices.ApiGet(token, "Person"));
        }


    }
}
