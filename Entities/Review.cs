namespace Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewText { get; set; }
        public int Stars { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public User User { get; set; }
    }
}
