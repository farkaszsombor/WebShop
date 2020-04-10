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
        public int Id { get; set; }
        public double SubTotal { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
