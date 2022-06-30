using Microsoft.AspNetCore.Mvc;
using botapi.Model;

namespace botapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodHistoryController : Controller
    {
        [HttpGet(Name = "FoodHistory")]

        public string FoodHistory(string date, long userid)
        {
            string message = $"Food history for {date}\n(food: calories)\n\n";
            string result;
            StreamReader k = new StreamReader(Constants.pathEatenProducts);
            while (!k.EndOfStream)
            {
                string s = k.ReadLine();

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<EatenProductModel>(s);                
                if (obj.tuinfoeatenproduct.date==date && obj.tuinfoeatenproduct.uinfoeatenproduct.userid == userid)
                {
                    message += $"{obj.tuinfoeatenproduct.uinfoeatenproduct.infoeatenproduct.product}: {obj.tuinfoeatenproduct.uinfoeatenproduct.infoeatenproduct.calories}\n";
                }
            }
            k.Close();

            if(message == $"Food history for {date}\n(food: calories)\n\n")
            {
                result = "There isn't enough information for this month";
            }
            else
            {
                result=message;
            }
            return result;                
        }
    }
}
