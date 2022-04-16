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
            return JsonConvert.DeserializeObject<List<BillBasic>>(apiServices.ApiGet(token, "Bill"));
        }

        public BillInfo GetBillInfo(string token, Guid? id)
        {
            return JsonConvert.DeserializeObject<BillInfo>(apiServices.ApiGet(token, "Bill/" + id));
        }

    }
}
