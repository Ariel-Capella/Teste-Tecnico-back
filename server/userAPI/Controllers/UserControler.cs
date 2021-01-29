using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using userAPI.Context;
using userAPI.Models;

namespace userAPI.Controllers
{
    // ADICIONAR UM SERVICE PARA REALIZAR OPERACOES DE BANCO EX "UserService"
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly UserContext UserDetails;

        public UserController(UserContext userContext)
        {
            UserDetails = userContext;
        }

        [HttpGet("GetUserList")]
        public IEnumerable<User> GetUserList()
        {
            List<User> userList = UserDetails.User.ToList();
            return userList;
        }

        [HttpPost]
        public IActionResult CreateNewUser([FromBody] User newUserEntry)
        {
            var data = UserDetails.User.Add(newUserEntry);
            UserDetails.SaveChanges();
            return Ok();
        }
    }
}
