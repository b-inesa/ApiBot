using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using botapi.Data;
using botapi.Model;

namespace botapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddProductOwnListController : Controller
    {
        [HttpPost(Name = "AddOwnProduct")]

        public string AddNewProduct(long userid, string name, int calories, double proteins, double fats, double carbohydrates)
        {
            var result = Data.Data.AddOwnProduct(userid, name, calories, proteins, fats, carbohydrates);
            return result;
        }

        
    }
}
