namespace BiketrackerFrontend.DataStruts
{
    public class PointGeometry
    {
        public string? type { get; set; } = "Point";
        public double[]? coordinates { get; set; }
        public Properties? properties { get; set; }
    }
}
