using JeudiPoker.Data.Infrastructure;
using JeudiPoker.Data.Repositories;
using JeudiPoker.Model.Models;

namespace JeudiPoker.Service
{
    public interface IGroupService : IService<Group>
    {
    }

    public class GroupService : ServiceBase<Group>, IGroupService
    {
        public GroupService(IGroupRepository groupRepository, IUnitOfWork unitOfWork) : base(groupRepository, unitOfWork)
        {
        }
    }
}