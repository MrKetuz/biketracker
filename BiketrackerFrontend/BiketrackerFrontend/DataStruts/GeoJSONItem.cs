namespace BiketrackerFrontend.DataStruts
{
    public class GeoJSONItem
    {
        public string? type { get; set; }
        public PointGeometry? geometry { get; set; }
        public visibilityZoomLevels? visibilityZoomLevels { get; set; }
    }
}
