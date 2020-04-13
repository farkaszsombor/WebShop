﻿namespace Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string Alt { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
