using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userAPI.Context;
using userAPI.Models;

namespace userAPI.Controllers
{
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

        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] int userId)
        {
            var userToDelete = await UserDetails.User.FindAsync(userId);
            UserDetails.User.Remove(userToDelete);
            await UserDetails.SaveChangesAsync();
            return Ok();
        }
    }
}
