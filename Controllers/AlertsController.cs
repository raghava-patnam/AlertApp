using AlertApp.Database;
using AlertApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlertApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlertsController : ControllerBase
    {

        private AppDBContext _dbContext;

        public AlertsController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet(Name = "GetAlerts")]
        public Reading GetAlerts()
        {
            return _dbContext.Readings.OrderByDescending(x => x.Time).First();
        }

        [HttpPost(Name = "AddPlant")]
        public void AddPlant([FromBody] string name)
        {
            var plant = new Plant
            {
                PlantName = name
            };
            _dbContext.Plants.Add(plant);
            _dbContext.SaveChanges();

        }

        [HttpPost(Name = "AddDevice")]
        public void AddDevice([FromBody] Device device)
        {
            _dbContext.Devices.Add(device);
            _dbContext.SaveChanges();
        }

        [HttpGet(Name = "GetDevices")]
        public IEnumerable<Device> GetDevices()
        {
            return _dbContext.Devices.ToList();
        }

        [HttpGet(Name = "GetPlants")]
        public IEnumerable<Plant> GetPlants()
        {
            return _dbContext.Plants.ToList();
        }

        [HttpPost(Name = "AddReading")]
        public void AddReading([FromBody] Reading reading)
        {
            _dbContext.Readings.Add(reading);
            _dbContext.SaveChanges();
        }
    }
}
