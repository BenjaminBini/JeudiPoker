using JeudiPoker.Data.Infrastructure;
using JeudiPoker.Data.Repositories;
using JeudiPoker.Model.Models;

namespace JeudiPoker.Service
{
    public interface IUserService : IService<ApplicationUser>
    {
    }

    public class UserService : ServiceBase<ApplicationUser>, IUserService
    {
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork) : base(userRepository, unitOfWork)
        {
        }
    }
}