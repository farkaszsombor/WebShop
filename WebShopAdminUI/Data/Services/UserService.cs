using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebShopAdminUI.Data.Models;

namespace WebShopAdminUI.Data
{
    public class UserService
    {
        private readonly HttpClient client;

        public UserService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            string response = await client.GetStringAsync("http://localhost:5000/api/user/get");
            System.Diagnostics.Debug.WriteLine("aaa " + response);
            List<User> users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(response);
            return users;
        }
    }
}
