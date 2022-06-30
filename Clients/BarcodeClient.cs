using Newtonsoft.Json;
using botapi.Model;

namespace botapi.Clients
{
    public class BarcodeClient
    {
        private HttpClient _client;
        private static string _address;

        public BarcodeClient()
        {
            _address = Constants.barcodeaddress;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_address);
            _client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "142c34c81bmshefe0369a756e595p1f7aefjsne37df9362b62");
        }

        public async Task<BarcodeModel> AddBarcode(string barcode)
        {
            var responce = await _client.GetAsync($"/apiBarcode.php?name={barcode}");
            responce.EnsureSuccessStatusCode();

            var content = responce.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<BarcodeModel>(content);

            return result;
        }
    }
}
