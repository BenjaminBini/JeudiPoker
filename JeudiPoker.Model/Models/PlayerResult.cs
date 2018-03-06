namespace JeudiPoker.Model.Models
{
    internal class PlayerResult
    {
        public Session Session { get; set; }

        public int SessionId { get; set; }

        public ApplicationUser Player { get; set; }

        public string ApplicationUserId { get; set; }
    }
}