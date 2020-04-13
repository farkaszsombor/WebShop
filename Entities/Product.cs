using System.Collections.Generic;

namespace Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double BuyPrice { get; set; }
        public double SalePrice { get; set; }
        public string ProductCode { get; set; }
        public string ImportCountryCode { get; set; }
        public string OrderLink { get; set; }
        public int Stock { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Type { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int? ParentId { get; set; }
        public Product Parent { get; set; } = null;

        public ICollection<Image> Images { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; }

        public ICollection<KeywordProduct> KeywordProducts { get; set; }
    }
}
