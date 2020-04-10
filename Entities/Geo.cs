using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
   public class Geo
    {
        [Key]
        public int Id { get; set; }
        public string County { get; set; }
        public string Locality { get; set; }
    }
}
