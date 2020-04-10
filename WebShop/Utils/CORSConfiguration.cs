using System.Collections.Generic;

namespace WebShop
{
    public class CORSConfiguration
    {
        public List<string> AllowedOrigins { get; set; }

        public List<string> AllowedMethods { get; set; }
    }
}
