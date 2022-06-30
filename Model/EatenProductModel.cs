using Newtonsoft.Json;

namespace botapi.Model
{
    public class EatenProductModel
    {
        public TUInfoEatenProduct tuinfoeatenproduct { get; set; }
       

    }
    public class TUInfoEatenProduct
    {        
        public string date { get; set; }
        public UInfoEatenProduct uinfoeatenproduct { get; set; }
    }
    public class UInfoEatenProduct
    {        
        public long userid { get; set; }
        public InfoEatenProduct infoeatenproduct { get; set; }
    }
    public class InfoEatenProduct
    {
        public string product { get; set; }
        public int calories { get; set; }

    }


}
