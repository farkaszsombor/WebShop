using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Product
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public double BuyPrice { get; set; }
        public double SalePrice { get; set; }
        public string ProductCode { get; set; }
        public string ImportCountryCode { get; set; }
        public string OrderLink { get; set; }
        public int Stock { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
    }
}
