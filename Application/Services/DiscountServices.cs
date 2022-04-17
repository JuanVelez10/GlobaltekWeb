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
    public class DiscountServices : IDiscountServices
    {
        private readonly IApiServices apiServices;

        public DiscountServices(IApiServices apiServices)
        {
            this.apiServices = apiServices;
        }

        public List<Discount> GetAll(string token)
        {
            return JsonConvert.DeserializeObject<List<Discount>>(apiServices.ApiGet(token, "Discount"));
        }

    }
}
