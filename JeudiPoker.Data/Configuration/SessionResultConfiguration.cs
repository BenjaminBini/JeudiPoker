using System.Data.Entity.ModelConfiguration;
using JeudiPoker.Model.Models;

namespace JeudiPoker.Data.Configuration
{
    public class SessionResultConfiguration : EntityTypeConfiguration<SessionResult>
    {
        public SessionResultConfiguration()
        {
            Property(r => r.Result).IsRequired();
            HasRequired(r => r.Session).WithMany(s => s.SessionResults).WillCascadeOnDelete(false);
            HasRequired(r => r.Player).WithMany(p => p.SessionResults).WillCascadeOnDelete(false);
        }
    }
}