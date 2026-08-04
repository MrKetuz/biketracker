using System.Text.Json.Serialization;

namespace BiketrackerBackend.Data
{
    public class RoutePoint
    {
        public long RouteId { get; set; }

        public int Sequence { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public float? Elevation { get; set; }
        public DateTime RecordedAt { get; set; }
        
        public Route Route { get; set; } = null!;
    }
}
