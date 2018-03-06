namespace JeudiPoker.Model.Models
{
    public class SessionResult
    {
        public int Id { get; set; }
        public ApplicationUser Player { get; set; }
        public string PlayerId { get; set; }
        public Session Session { get; set; }
        public int SessionId { get; set; }
        public float Result { get; set; }
    }
}