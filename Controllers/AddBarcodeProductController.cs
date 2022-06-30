using Microsoft.AspNetCore.Mvc;
using botapi.Model;
using botapi.Clients;

namespace botapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddBarcodeProductController : Controller
    {
        [HttpGet(Name = "AddBarcodeProduct")]

        public async Task<string> AddBarcode(string barcode, string portion, string date, long userid)
        {
            string result;             
            try
            {
                double amount = Double.Parse(portion);
                BarcodeClient client = new BarcodeClient();
                int caloric = (int)(Int32.Parse(client.AddBarcode(barcode).Result.dishes[0].caloric) * amount);
                string[] Fat = client.AddBarcode(barcode).Result.dishes[0].fat.Split('.');
                int fat = (int)(Int32.Parse(Fat[0]) * amount);
                string[] Carbon= client.AddBarcode(barcode).Result.dishes[0].carbon.Split('.');
                int carbon = (int)(Double.Parse(Carbon[0]) * amount);
                string[] Protein = client.AddBarcode(barcode).Result.dishes[0].protein.Split('.');
                int protein = (int)(Double.Parse(Protein[0]) * amount);

                if (caloric == 0)
                {
                    result = "Sorry, we couldn't find this product";
                }
                else
                {                    
                    result = $"{client.AddBarcode(barcode).Result.dishes[0].name} \n{caloric} calories \nfat:{fat} \ncarbon:{carbon} \nprotein:{protein}";
                }
            }
            catch(Exception ex)
            {
                result = "Sorry, we couldn't find this product";
            }
            return result;
        }
    }
}
