namespace BiketrackerBackend.Data
{
    public class Route
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string? Name { get; set; }

        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public double? DistanceMeters { get; set; }

        public User User { get; set; } = null!;

        public ICollection<RoutePoint> Points { get; set; } = new List<RoutePoint>();
    }
}
