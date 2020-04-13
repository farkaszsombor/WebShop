namespace Entities
{
   public class Geo
    {
        public int Id { get; set; }
        public string County { get; set; }
        public string Locality { get; set; }

        public User User { get; set; }
    }
}
