namespace Models
{
    public class RoyalFamily
    {
        public string Name { get; set; }    
        public List<Person> Persons { get; set; } = new List<Person>();
    }
}
