using System.Data.Entity.ModelConfiguration;
using JeudiPoker.Model.Models;

namespace JeudiPoker.Data.Configuration
{
    public class SessionConfiguration : EntityTypeConfiguration<Session>
    {
        public SessionConfiguration()
        {
            ToTable("Session");
            Property(s => s.Date).IsRequired();
            Property(s => s.Place).IsRequired();

            HasRequired(s => s.Group);
        }
    }
}