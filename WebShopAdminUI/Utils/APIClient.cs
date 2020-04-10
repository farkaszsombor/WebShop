using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebShopAdminUI
{
    public class APIClient
    {
        private readonly HttpClient httpClient;

        public APIClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> GetStringAsync(string requestUri)
        {
            return await httpClient.GetStringAsync(requestUri);
        }

        public async Task<string> GetAsync(Uri requestUri)
        {
            return await httpClient.GetStringAsync(requestUri);
        }

        // Implement a proxy for HttpClient methods, see above variants
    }
}
