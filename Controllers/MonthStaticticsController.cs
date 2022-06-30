using Microsoft.AspNetCore.Mvc;
using botapi.Model;

namespace botapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonthStaticticsController : Controller
    {
        [HttpGet(Name = "MonthStatistics")]

        public string Monthstatictics(long userid, string date)
        {
            Dictionary<string,int> daynorms=new Dictionary<string,int>();
            Dictionary<string, int> daycalories = new Dictionary<string, int>();
            string result;
            
            StreamReader f = new StreamReader(Constants.pathDailyNorm);
             while (!f.EndOfStream)
            {
                string s = f.ReadLine();

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<SetNormModel>(s);
                var datem = Convert.ToDateTime(obj.infosetnorm._date);
                var month = datem.Month;
                if (obj.infosetnorm._userid == userid && month.ToString() == date)
                {
                    daynorms.Add(obj.infosetnorm._date, obj.infosetnorm._normcalories);
                }
            }
            f.Close();

            StreamReader k = new StreamReader(Constants.pathEatenProducts);
            while (!k.EndOfStream)
            {
                string s = k.ReadLine();

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<EatenProductModel>(s);
                var datem = Convert.ToDateTime(obj.tuinfoeatenproduct.date);
                var month = datem.Month;
                if (month.ToString() == date && obj.tuinfoeatenproduct.uinfoeatenproduct.userid == userid)
                {
                    if(daycalories.ContainsKey(obj.tuinfoeatenproduct.date))
                    {
                        daycalories[obj.tuinfoeatenproduct.date] += obj.tuinfoeatenproduct.uinfoeatenproduct.infoeatenproduct.calories;
                    }
                    else
                    {
                        daycalories.Add(obj.tuinfoeatenproduct.date, obj.tuinfoeatenproduct.uinfoeatenproduct.infoeatenproduct.calories);
                    }                                       
                }
            }
            k.Close();
            string message = "day\neaten/norm\n\n"; ;
            foreach (var norm in daynorms)
            {
                foreach (var food in daycalories)
                {
                    if (norm.Key == food.Key)
                    {
                        message += $"{food.Key}\n{food.Value}/{norm.Value}\n\n";
                        
                    }
                }
            }
            if(message== "day\neaten/norm\n\n")
            {
                result = "There isn't enough information for this month";
            }
            else
            {
                result = message;
            }
            return result;
        }
    }
}
