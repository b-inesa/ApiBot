using Microsoft.AspNetCore.Mvc;
using botapi.Model;

namespace botapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowListOwnProductsController : Controller
    {
        [HttpGet(Name = "ShowOwnProducts")]
        public string ShowOwnProducts(long userid)
        {
            bool exist = false;
            string result = null;
            List<AddOwnProductModel> products = new List<AddOwnProductModel>();
            StreamReader f = new StreamReader(Constants.pathListOwnProducts);
            while (!f.EndOfStream)
            {
                string s = f.ReadLine();

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<AddOwnProductModel>(s);
                if (obj.Userid == userid)
                {
                    products.Add(obj);
                    exist = true;
                }
            }
            f.Close();
            if (exist == false)
            {
                result = "You haven't yet added any products to the list \nDo this by choosing an action \n/addproducttomyproductlist";
            }
            else
            {
                foreach (var item in products)
                {
                    result += $"{item.Name}\ncalories:{item.ProductItems.Calories}\nproteins:{item.ProductItems.Proteins}\nfats:{item.ProductItems.Fats}\ncarbohydrates:{item.ProductItems.Carbohydrates}\n\n";
                }
            }
            return result;

        }        
    }
}
