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

        public List<BillBasic> GetAllBill(string token)
        {
            return JsonConvert.DeserializeObject<List<BillBasic>>(apiServices.ApiGet("Bill", token));
        }

        public BillInfo GetBillInfo(string token, Guid? id)
        {
            return JsonConvert.DeserializeObject<BillInfo>(apiServices.ApiGet("Bill/" + id, token));
        }

        public bool SaveInfo(string token, BillInfo billInfo)
        {
            var save = false;
            BaseResponse<bool> baseResponse;
            if (billInfo == null) return save;

            billInfo.NamePerson = string.Empty;
            billInfo.DocumenPerson = string.Empty;

            foreach (var details in billInfo.BillDetails)
            {
                details.Id = new Guid();
                details.BillId = new Guid();
                details.NameProduct = string.Empty;
            }

            var json = JsonConvert.SerializeObject(billInfo);
            try
            {
                if (billInfo.Update) baseResponse = JsonConvert.DeserializeObject<BaseResponse<bool>>(apiServices.ApiPut(json, "Bill", token));
                else baseResponse = JsonConvert.DeserializeObject<BaseResponse<bool>>(apiServices.ApiPost(json, "Bill", token));
            }
            catch
            {
               return false;
            }


            return baseResponse.Data;
        }

    }
}
