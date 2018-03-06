using JeudiPoker.Data.Infrastructure;
using JeudiPoker.Model.Models;

namespace JeudiPoker.Data.Repositories
{
    public class SessionResultRepository : RepositoryBase<SessionResult>, ISessionResultRepository
    {
        public SessionResultRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ISessionResultRepository : IRepository<SessionResult>
    {
    }
}