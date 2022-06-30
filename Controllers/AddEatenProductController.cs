using Microsoft.AspNetCore.Mvc;
using botapi.Model;
using botapi.Data;
using botapi.Clients;

namespace botapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddEatenProductController : ControllerBase
    {
        [HttpGet(Name = "AddEatenProduct")]
        public async Task<string> GetCaloriesEatenProduct(string date, long userid, string product)
        {
            string result;
            CaloryClient client = new CaloryClient();          
            EatenProductModel epm = new EatenProductModel
            {
                tuinfoeatenproduct = new TUInfoEatenProduct
                {
                    date = date,
                    uinfoeatenproduct = new UInfoEatenProduct
                    {
                        userid = userid,
                        infoeatenproduct = new InfoEatenProduct
                        {
                            product = product,
                            calories = client.GetCalory(product).Result.calories

                        }
                    }
                }

            };
            if (epm.tuinfoeatenproduct.uinfoeatenproduct.infoeatenproduct.calories == 0)
            {
                result = "You have entered incomplete or incorrect information \nTry again";
            }
            else
            {
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(epm);
                using (StreamWriter writer = new StreamWriter(Constants.pathEatenProducts, true))
                {
                    writer.WriteLine(jsonString);
                }
                result= "Product added";
            }
            return result;
        }        
    }
}
