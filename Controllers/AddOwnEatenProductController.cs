using Microsoft.AspNetCore.Mvc;
using botapi.Model;
using Newtonsoft.Json;

namespace botapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddOwnEatenProductController : Controller
    {
        [HttpPost(Name = "AddOwnEatenProduct")]
        public string AddOwnEatenProduct(string date, long userid, string product)
        {
            string result = "There isn't product with this name in the list";
            int readcalories = 0;
            StreamReader f = new StreamReader(Constants.pathListOwnProducts);
            while (!f.EndOfStream)
            {
                string s = f.ReadLine();

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<AddOwnProductModel>(s);

                if (obj.Userid==userid && obj.Name==product)
                {
                    readcalories = obj.ProductItems.Calories;
                }
            }
            f.Close();

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
                            calories = readcalories

                        }
                    }
                }

            };
            if (readcalories != 0)
            {
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(epm);
                using (StreamWriter writer = new StreamWriter(Constants.pathEatenProducts, true))
                {
                    writer.WriteLine(jsonString);
                }
                result = "Product added";
            }
            
            return result;
        }        
    }
    
}
