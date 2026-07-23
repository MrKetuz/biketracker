using LeafletForBlazor;

namespace BiketrackerFrontend.DataStruts
{
    public class GeoJSONLayer
    {
        public string? name { get; set; }
        public GeoJSONItem[]? data { get; set; }
        public GeoJSONApperance? appearance { get; set; }
        public RealTimeMap.VisibilityZoomLevel? visibilityZoomLevel { get; set; }
    }
}
