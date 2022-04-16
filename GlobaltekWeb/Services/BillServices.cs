using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Web.Models;

namespace Web.Services
{
    public class BillServices
    {
        public BillServices() { }

        public BaseResponse<Login> Login(LoginRequest loginRequest)
        {
            try
            {
                var json = JsonConvert.SerializeObject(loginRequest);
                return JsonConvert.DeserializeObject<BaseResponse<Login>>(ApiPost(json, "https://localhost:7118/api/Person/Login"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<BillBasic> GetAllBill(string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<BillBasic>>(ApiGet(token, "https://localhost:7118/api/Bill"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private string ApiPost(string json, string url)
        {

            var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            using var client = new HttpClient();

            var response = client.PostAsync(url, content).Result;

            var result = response.Content.ReadAsStringAsync();

            return result.Result;

        }

        private string ApiGet(string token, string url)
        {

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var response = client.GetAsync(url).Result;

            var result = response.Content.ReadAsStringAsync();

            return result.Result;

        }

    }
}
