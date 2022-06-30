namespace botapi.Model
{
    public class BarcodeModel
    {
        public List<Dishes> dishes { get; set; }
    }

    public class Dishes
    {
        public string name { get; set; }
        public string caloric { get; set; }
        public string fat { get; set; }
        public string carbon { get; set; }
        public string protein { get; set; }


    }

}
