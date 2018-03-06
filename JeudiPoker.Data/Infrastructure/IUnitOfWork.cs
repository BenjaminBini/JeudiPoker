namespace JeudiPoker.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}