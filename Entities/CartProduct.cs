﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class CartProduct
    {
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
