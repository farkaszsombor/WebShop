using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public string Holder { get; set; }
        public string Number { get; set; }
        public int Cvv { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
