using Microsoft.AspNetCore.Mvc;
using botapi.Model;
using Newtonsoft.Json;

namespace botapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControlNormCaloriesController : Controller
    {
        [HttpGet(Name = "ControlMormCalories")]

        public string ControlNorm(string date, long userid)
        {
            int daynorm=0;
            int eatencalories =0;
            string message = null;
            string result = null;
            StreamReader f = new StreamReader(Constants.pathDailyNorm);
            while (!f.EndOfStream)
            {
                string s = f.ReadLine();

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<SetNormModel>(s);
                if (obj.infosetnorm._userid == userid && obj.infosetnorm._date == date)
                {
                    daynorm = obj.infosetnorm._normcalories;
                    break;
                }
            }
            f.Close();

            StreamReader k = new StreamReader(Constants.pathEatenProducts);
            while (!k.EndOfStream)
            {
                string s = k.ReadLine();

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<EatenProductModel>(s);
                if (obj.tuinfoeatenproduct.date==date && obj.tuinfoeatenproduct.uinfoeatenproduct.userid==userid)
                {
                    eatencalories += obj.tuinfoeatenproduct.uinfoeatenproduct.infoeatenproduct.calories;
                }
            }
            k.Close();
            if (eatencalories<=daynorm)
            {
                message = "You follow the norm";
            }
            else
            {
                message = "You have exceeded the norm";
            }

            if (daynorm==0)
            {
                result = "You haven't yet set a daily calorie norm";
            }
            else
            {
                result = $"{eatencalories}/{daynorm} \n{message}";
            }
            
            return result;
        }        
    }
}
