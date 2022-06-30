using Microsoft.AspNetCore.Mvc;
using botapi.Clients;
using botapi.Model;

namespace botapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaloriesController : ControllerBase
    {
        [HttpGet(Name = "GetCaloriesValue")]
        public GetCaloriesModel GetCalories(string product)
        {
            CaloryClient client = new CaloryClient();
            return client.GetCalory(product).Result;

        }        
    }
}



