﻿using Application.Interfaces;
using Domain.Dtos;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApiServices: IApiServices
    {
        private readonly Api api;

        public ApiServices(IOptions<Api> api)
        {
            this.api = api.Value;
        }

        public string ApiPost(string json, string service)
        {
            var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = client.PostAsync(api.Url + service, content).Result;
            var result = response.Content.ReadAsStringAsync();
            return result.Result;

        }

        public string ApiGet(string token, string service)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = client.GetAsync(api.Url + service).Result;
            var result = response.Content.ReadAsStringAsync();
            return result.Result;
        }

    }
}
