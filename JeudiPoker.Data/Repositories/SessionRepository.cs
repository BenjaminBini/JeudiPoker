using JeudiPoker.Data.Infrastructure;
using JeudiPoker.Model.Models;

namespace JeudiPoker.Data.Repositories
{
    public class SessionRepository : RepositoryBase<Session>, ISessionRepository
    {
        public SessionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ISessionRepository : IRepository<Session>
    {
    }
}