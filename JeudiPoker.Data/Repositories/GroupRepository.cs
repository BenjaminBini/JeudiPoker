using JeudiPoker.Data.Infrastructure;
using JeudiPoker.Model.Models;

namespace JeudiPoker.Data.Repositories
{
    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        public GroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IGroupRepository : IRepository<Group>
    {
    }
}