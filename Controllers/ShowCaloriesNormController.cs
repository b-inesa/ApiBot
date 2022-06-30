using Microsoft.AspNetCore.Mvc;
using botapi.Model;

namespace botapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowCaloriesNormController : Controller
    {
        [HttpGet(Name = "ShowCaloriesNorm")]
        public string ShowNorm(string date, long userid)
        {
            string result = "0";
            StreamReader f = new StreamReader(Constants.pathDailyNorm);
            while (!f.EndOfStream)
            {
                string s = f.ReadLine();

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<SetNormModel>(s);
                if (obj.infosetnorm._userid==userid && obj.infosetnorm._date == date)
                {
                    result = obj.infosetnorm._normcalories.ToString();
                }                
            }
            f.Close();
            return result;
        }
        
    }
}
