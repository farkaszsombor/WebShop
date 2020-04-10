using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        List<User> users = new List<User>();

        public UserController()
        {
            users.Add(
                new User()
                {
                    Id = 1,
                    FirstName = "Farkas",
                    LastName = "Zsombor"
                }
                );
            users.Add(
                new User()
                {
                    Id = 2,
                    FirstName = "Rapa",
                    LastName = "Erik"
                });
        }

        [HttpGet]
        [Route("get")]
        public List<User> GetUsersAsync()
        {
            return users;
        }
    }
}