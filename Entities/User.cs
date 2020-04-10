using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public int OrdersCount { get; set; }

        public Geo Geo { get; set; } = null;
        public Card Card { get; set; } = null;
        public Cart Cart { get; set; }
    }
}
