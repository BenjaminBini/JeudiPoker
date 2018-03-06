using JeudiPoker.Data.Infrastructure;
using JeudiPoker.Data.Repositories;
using JeudiPoker.Model.Models;

namespace JeudiPoker.Service
{
    public interface ISessionResultService : IService<SessionResult>
    {
    }

    public class SessionResultService : ServiceBase<SessionResult>, ISessionResultService
    {
        public SessionResultService(ISessionResultRepository sessionResultRepository, IUnitOfWork unitOfWork) : base(sessionResultRepository, unitOfWork)
        {
        }
    }
}