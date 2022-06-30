namespace botapi.Model
{
    public class SetNormModel
    {
       public InfoSetNorm infosetnorm { get; set; }
    }
    public class InfoSetNorm
    {
        public string _date { get; set; }
        public long _userid { get; set; }      
        public int _normcalories { get; set; }       
        
    }
}
