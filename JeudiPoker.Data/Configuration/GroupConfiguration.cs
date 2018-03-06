using System.Data.Entity.ModelConfiguration;
using JeudiPoker.Model.Models;

namespace JeudiPoker.Data.Configuration
{
    public class GroupConfiguration : EntityTypeConfiguration<Group>
    {
        public GroupConfiguration()
        {
            ToTable("Group");
            Property(g => g.Name).IsRequired().HasMaxLength(255);

            HasMany(g => g.Players).WithMany(p => p.Groups);

            HasRequired(g => g.Creator).WithMany().WillCascadeOnDelete(false);
        }
    }
}