using Microsoft.AspNetCore.Mvc;
using BiketrackerBackend.Data;
using BiketrackerBackend.DTO;
using Microsoft.EntityFrameworkCore;


namespace BiketrackerBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BikeDataController : ControllerBase
    {
        private readonly BiketrackerDbContext _db;

        public BikeDataController(BiketrackerDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetBikeData()
        {
            // Implementation for getting bike data
            return Ok("Very Cool");
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoute(CreateRouteRequest request)
        {
            var route = new Data.Route
            {
                UserId = request.UserId,
                Name = request.Name,
                CreatedAt = DateTime.UtcNow
            };

            int sequence = 0;

            foreach (var point in request.Points)
            {
                route.Points.Add(new RoutePoint
                {
                    Sequence = sequence++,
                    Latitude = point.Lat,
                    Longitude = point.Lng,
                    RecordedAt = point.timestamp
                });
            }
            _db.Routes.Add(route);
            await _db.SaveChangesAsync();
            return Ok("Route created successfully");
        }
        [HttpGet("routes/{routeId:long}")]
        public async Task<IActionResult> GetRouteById(long routeId)
        {
            var route = await _db.Routes
                .AsNoTracking()
                .Include(r => r.Points)
                .FirstOrDefaultAsync(r => r.Id == routeId);

            if (route == null)
            {
                return NotFound();
            }

            var response = new RouteResponse
            {
                Id = route.Id,
                Name = route.Name,
                Points = route.Points
                    .OrderBy(p => p.Sequence)
                    .Select(p => new RoutePointResponse
                    {
                        Sequence = p.Sequence,
                        Latitude = p.Latitude,
                        Longitude = p.Longitude,
                        RecordedAt = p.RecordedAt
                    })
                    .ToList()
            };

            return Ok(response);
        }
        //[HttpGet("user/{userId:long}")]
        //public async Task<IActionResult> GetUserRoutes(long userId)
        //{
        //    var routes = await _db.Routes
        //        .AsNoTracking()
        //        .Where(r => r.UserId == userId)
        //        .ToListAsync();

        //    return Ok(routes);
        //}
        [HttpGet("user/{username}")]
        public async Task<IActionResult> GetUserRoutesByUsername(string username)
        {
            var user = await _db.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                return NotFound();
            }
            var routes = await _db.Routes
                .AsNoTracking()
                .Where(r => r.UserId == user.Id)
                .ToListAsync();
            return Ok(routes);
        }
    }
}
