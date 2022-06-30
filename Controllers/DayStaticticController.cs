using Microsoft.AspNetCore.Mvc;
using botapi.Model;

namespace botapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DayStaticticController : Controller
    {
        [HttpGet(Name = "DayStatistic")]

        public string Daystatistic(string date, long userid)
        {
            int daynorm = 0;
            int eatencalories = 0;
            string message;
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
                if (obj.tuinfoeatenproduct.date == date && obj.tuinfoeatenproduct.uinfoeatenproduct.userid == userid)
                {
                    eatencalories += obj.tuinfoeatenproduct.uinfoeatenproduct.infoeatenproduct.calories;
                }
            }
            k.Close();

            string result = $"{eatencalories}/{daynorm}";
            if (result=="0/0")
            {
                message = $"statistics for {date}: \nthere is no data";
            }
            else
            {
                message = $"statistics for {date}: \neaten/norm \n{result}";
            }
            return message;
        }
    }
}
