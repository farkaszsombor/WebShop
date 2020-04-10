using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
        public string ReviewText { get; set; }
        public int Stars { get; set; }
    }
}
