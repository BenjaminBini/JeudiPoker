using System.Data.Entity.ModelConfiguration;
using JeudiPoker.Model.Models;

namespace JeudiPoker.Data.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public UserConfiguration()
        {
            ToTable("AspNetUsers");
        }
    }
}