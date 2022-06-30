using System.Runtime.InteropServices;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using botapi.Model;


namespace botapi.Clients
{
    public class CaloryClient
    {
        private HttpClient _client;
        private static string _address;        
        
        public CaloryClient()
        {
            _address = Constants.caloryaddress;
            
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_address);
            _client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "887b57ebcdmsh65f8b8c30b6e687p18b977jsndd10c53d304e");
        }

        public async Task<GetCaloriesModel> GetCalory(string product)
        {
            var responce = await _client.GetAsync($"/api/nutrition-data?ingr={product}");
            responce.EnsureSuccessStatusCode();

            var content = responce.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<GetCaloriesModel>(content);

            return result;
        }
    }
}