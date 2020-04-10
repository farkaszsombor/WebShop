using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ParentId")]
        public Category Parent { get; set; } = null;
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
