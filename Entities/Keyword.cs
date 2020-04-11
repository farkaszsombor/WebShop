using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Keyword
    {
        [Key]
        public int Id { get; set; }
        public string KeyWord { get; set; }
        public List<KeywordProduct> KeywordProducts { get; set; }
    }
}
