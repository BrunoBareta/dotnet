namespace API_CSV.database.models
{
    public class Animal
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Classification { get; set; }
        public string Origin { get; set; }
        public string Reproduction { get; set; }
        public string Feeding { get; set; }
        public object Feedding { get; internal set; }
    }
}
