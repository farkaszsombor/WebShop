using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebShopAdminUI.Data.Models;

namespace WebShopAdminUI.Data
{
    public class UserService
    {
        private readonly APIClient client;

        public UserService(APIClient client)
        {
            this.client = client;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            string response = await client.GetStringAsync("user/get");
            List<User> users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(response);
            return users;
        }
    }
}
