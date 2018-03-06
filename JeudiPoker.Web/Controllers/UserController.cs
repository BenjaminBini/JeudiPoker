using System.Linq;
using System.Web.Http;
using JeudiPoker.Service;
using JeudiPoker.Web.Dtos;

namespace JeudiPoker.Web.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET /api/user
        public IHttpActionResult GetUsers()
        {
            return Ok(_userService.Get().Select(u => new UserDto(u)));
        }

        // GET /api/user/1
        public IHttpActionResult GetUser(string id)
        {
            var user = _userService.GetOne(u => u.Id == id);

            if (user == null)
                return NotFound();

            return Ok(new UserDto(user));
        }
    }
}