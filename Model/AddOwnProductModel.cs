namespace botapi.Model
{
    public class AddOwnProductModel
    {
        public long Userid { get; set; }
        public string Name { get; set; }        
        public Items ProductItems { get; set; }
    }
    public class Items
    {
        public int Calories { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
    }
}
