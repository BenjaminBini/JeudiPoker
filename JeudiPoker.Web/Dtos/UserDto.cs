using JeudiPoker.Model.Models;

namespace JeudiPoker.Web.Dtos
{
    public class UserDto
    {
        public UserDto(ApplicationUser user)
        {
            Id = user.Id;
            UserName = user.UserName;
        }

        public string Id { get; set; }
        public string UserName { get; set; }
    }
}