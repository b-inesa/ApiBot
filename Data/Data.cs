using botapi.Model;
using Newtonsoft.Json;

namespace botapi.Data
{
    public class Data
    {
        public static void SetCaloriesNorm(string date,long userid, int daycalories)
        {
            List<SetNormModel> newDailyNorm = new List<SetNormModel>();
            StreamReader f = new StreamReader(Constants.pathDailyNorm);
            while (!f.EndOfStream)
            {
                string s = f.ReadLine();

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<SetNormModel>(s);
                if (obj.infosetnorm._date==date && obj.infosetnorm._userid==userid)
                {
                    s = null;
                }
                else
                {
                    newDailyNorm.Add(obj);
                }

            }
            f.Close();
            File.WriteAllText(Constants.pathDailyNorm, string.Empty);

            SetNormModel stm = new SetNormModel
            {
                infosetnorm = new InfoSetNorm
                {

                    _date = date,
                    _userid = userid,
                    _normcalories = daycalories

                }
            };
            newDailyNorm.Add(stm);
            foreach (var norm in newDailyNorm)
            {
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(norm);
                using (StreamWriter writer = new StreamWriter(Constants.pathDailyNorm, true))
                {
                    writer.WriteLine(jsonString);
                }
            }
            
        }

        public static void ReadEatenProduct()
        {
            StreamReader f = new StreamReader(Constants.pathEatenProducts);
            while (!f.EndOfStream)
            {
                string s = f.ReadLine();

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<EatenProductModel>(s);
                
                Console.WriteLine(obj.tuinfoeatenproduct.uinfoeatenproduct.infoeatenproduct.calories);
                Console.WriteLine(obj.tuinfoeatenproduct.uinfoeatenproduct.infoeatenproduct.product);               
            }
            f.Close();
        }
        
        public static string AddOwnProduct(long userid, string name,int calories, double proteins, double fats, double carbohydrates)
        {

            string result = "Product added";
            bool exist = false;
            List<AddOwnProductModel> newproducts = new List<AddOwnProductModel>();
            StreamReader f = new StreamReader(Constants.pathListOwnProducts);
            while (!f.EndOfStream)
            {
                string s = f.ReadLine();

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<AddOwnProductModel>(s);
                if (obj.Userid==userid && obj.Name==name)
                {
                    result = "Product with this name already exists \nTry again with a different name ";
                    exist = true;
                }
                newproducts.Add(obj);
                
            }
            f.Close();
            File.WriteAllText(Constants.pathListOwnProducts, string.Empty);
            AddOwnProductModel product = new AddOwnProductModel
            {
                Name = name,
                Userid = userid,
                ProductItems = new Items
                {
                    Calories = calories,
                    Proteins = proteins,
                    Fats = fats,
                    Carbohydrates = carbohydrates
                }

            };
            if (exist == false)
            {
                newproducts.Add(product);
            }
            foreach (var products in newproducts)
            {
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(products);
                using (StreamWriter writer = new StreamWriter(Constants.pathListOwnProducts, true))
                {
                    writer.WriteLine(jsonString);
                }
            }
            return result;
        }
       
        public static string DeleteProduct(long id, string product)
        {
            string result = "There isn't product with this name in the list";
            List<AddOwnProductModel> productlist = new List<AddOwnProductModel>();
            StreamReader f = new StreamReader(Constants.pathListOwnProducts);
            while (!f.EndOfStream)
            {
                string s = f.ReadLine();

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<AddOwnProductModel>(s);

                if (obj.Userid == id && obj.Name == product)
                {
                    result = "Product removed";
                }
                else
                {
                    productlist.Add(obj);
                }
            }
            f.Close();
            File.WriteAllText(Constants.pathListOwnProducts, string.Empty);
            foreach (var products in productlist)
            {
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(products);
                using (StreamWriter writer = new StreamWriter(Constants.pathListOwnProducts, true))
                {
                    writer.WriteLine(jsonString);
                }
            }
            return result;
        }
    }

       
    
}
