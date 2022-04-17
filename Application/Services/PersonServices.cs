using Application.Interfaces;
using Domain.Dtos;
using Domain.Entities;
using Domain.References;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums.Enums;

namespace Application.Services
{
    public  class PersonServices: IPersonServices
    {
        private readonly IApiServices apiServices;
        private readonly ILogger<PersonServices> _logger;

        public PersonServices(IApiServices apiServices, ILogger<PersonServices> logger)
        {
            _logger = logger;
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
