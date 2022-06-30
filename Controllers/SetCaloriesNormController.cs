using Microsoft.AspNetCore.Mvc;
using botapi.Data;
using botapi.Model;

namespace botapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SetCaloriesNormController : ControllerBase
    {
        [HttpPost(Name = "SetCaloriesValue")]

        public void SetCaloriesNorm(string date, long userid, int daycalories)
        {            
            Data.Data.SetCaloriesNorm(date, userid, daycalories);
        }
    }
}
