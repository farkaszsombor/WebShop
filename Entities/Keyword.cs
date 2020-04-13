using System.Collections.Generic;

namespace Entities
{
    public class Keyword
    {
        public int Id { get; set; }
        public string KeyWord { get; set; }

        public int KeywordProductId { get; set; }
        public ICollection<KeywordProduct> KeywordProducts { get; set; }
    }
}
