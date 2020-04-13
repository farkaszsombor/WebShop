using System;

namespace Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string Holder { get; set; }
        public string Number { get; set; }
        public int Cvv { get; set; }
        public DateTime ExpirationDate { get; set; }

        public User User { get; set; }
    }
}
