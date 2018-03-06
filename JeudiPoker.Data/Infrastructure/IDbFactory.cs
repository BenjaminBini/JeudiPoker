using System;

namespace JeudiPoker.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        PokerDbContext Init();
    }
}