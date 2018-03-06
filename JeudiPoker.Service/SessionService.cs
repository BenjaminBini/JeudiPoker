using JeudiPoker.Data.Infrastructure;
using JeudiPoker.Data.Repositories;
using JeudiPoker.Model.Models;

namespace JeudiPoker.Service
{
    public interface ISessionService : IService<Session>
    {
    }

    public class SessionService : ServiceBase<Session>, ISessionService
    {
        public SessionService(ISessionRepository sessionRepository, IUnitOfWork unitOfWork) : base(sessionRepository, unitOfWork)
        {
        }
    }
}