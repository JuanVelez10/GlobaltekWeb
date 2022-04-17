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
    public class ProductServices: IProductServices
    {
        private readonly IApiServices apiServices;

        public ProductServices(IApiServices apiServices)
        {
            this.apiServices = apiServices;
        }

        public List<Product> GetAll(string token)
        {
            return JsonConvert.DeserializeObject<List<Product>>(apiServices.ApiGet("Product", token));
        }

    }
}
