namespace BiketrackerBackend.Data
{
    public class User
    {
        public long Id { get; set; }

        public string Username { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public ICollection<Route> Routes { get; set; } = new List<Route>();
    }
}
