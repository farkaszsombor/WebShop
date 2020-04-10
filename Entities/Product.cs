﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
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

        public Category Category { get; set; }
        
        public List<Image> Images { get; set; }
        
        public Product Parent { get; set; }

        public List<CartProduct> CartProducts { get; set; }

        public List<KeywordProduct> KeywordProducts { get; set; }
    }
}
