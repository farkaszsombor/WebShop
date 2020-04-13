namespace Entities
{
    public class KeywordProduct
    {
        public int KeywordId { get; set; }
        public Keyword Keyword { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
