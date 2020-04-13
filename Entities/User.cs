namespace Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public int OrdersCount { get; set; }

        public int GeoId { get; set; }
        public Geo Geo { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
