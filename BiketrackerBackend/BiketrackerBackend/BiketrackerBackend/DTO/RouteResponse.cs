namespace BiketrackerBackend.DTO
{
    public class RouteResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<RoutePointResponse> Points { get; set; } = new();
    }
}
