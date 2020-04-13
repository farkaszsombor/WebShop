using System.Collections.Generic;

namespace Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public double SubTotal { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; }

        public User User { get; set; }
    }
}
