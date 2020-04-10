using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public double SubTotal { get; set; }


        public List<CartProduct> CartProducts { get; set; }
    }
}
