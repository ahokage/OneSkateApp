namespace OneSkate.Web.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Racer> Racers { get; set; }
    }
}
