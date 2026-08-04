namespace BiketrackerBackend.DTO
{
    public class CreateRouteRequest
    {
        public string Name { get; set; } = null!;
        public long UserId { get; set; }
        public List<RoutePointRequest> Points { get; set; } = new();
    }
}
