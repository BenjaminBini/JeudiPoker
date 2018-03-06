namespace JeudiPoker.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private PokerDbContext _dbContext;

        public PokerDbContext Init()
        {
            return _dbContext ?? (_dbContext = new PokerDbContext());
        }

        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }
}