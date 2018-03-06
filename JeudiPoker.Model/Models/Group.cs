using System.Collections.Generic;

namespace JeudiPoker.Model.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ApplicationUser Creator { get; set; }
        public string CreatorId { get; set; }
        public virtual ICollection<ApplicationUser> Players { get; set; }
    }
}