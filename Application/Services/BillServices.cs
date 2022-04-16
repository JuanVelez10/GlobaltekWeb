using Application.Interfaces;
using Domain.Dtos;
using Domain.Entities;
using Domain.References;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BillServices: IBillServices
    {

        private IApiServices apiServices;

        public BillServices(IApiServices apiServices)
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

        public List<BillBasic> GetAllBill(string token)
        {
            List<BillBasic> billBasics = new List<BillBasic>();

            try
            {
                billBasics = JsonConvert.DeserializeObject<List<BillBasic>>(apiServices.ApiGet(token, "Bill"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return billBasics;

        }

    }
}
