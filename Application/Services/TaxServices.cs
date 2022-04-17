using Application.Interfaces;
using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TaxServices: ITaxServices
    {
        private readonly IApiServices apiServices;

        public TaxServices(IApiServices apiServices)
        {
            this.apiServices = apiServices;
        }

        public List<Tax> GetAll(string token)
        {
            return JsonConvert.DeserializeObject<List<Tax>>(apiServices.ApiGet(token, "Tax"));
        }
    }
}
