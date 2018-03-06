using System;
using System.Collections.Generic;

namespace JeudiPoker.Model.Models
{
    public class Session
    {
        public int Id { get; set; }

        public string Place { get; set; }

        public DateTime Date { get; set; }

        public Group Group { get; set; }

        public int GroupId { get; set; }

        public virtual ICollection<SessionResult> SessionResults { get; set; }
    }
}