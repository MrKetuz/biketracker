namespace BiketrackerFrontend.DataStruts
{
    public class RouteSegment
    {
        public GpsPoint Start { get; set; } = null;
        public GpsPoint End { get; set; } = null;
        
        public double distanceMeter { get; set; }
        public double averageSpeedKmh { get; set; }
        
    }
}
