using JeudiPoker.Data.Infrastructure;
using JeudiPoker.Model.Models;

namespace JeudiPoker.Data.Repositories
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IUserRepository : IRepository<ApplicationUser>
    {
    }
}