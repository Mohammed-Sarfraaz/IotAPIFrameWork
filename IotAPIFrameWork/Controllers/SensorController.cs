using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ValeIotApi.Entities;

namespace ValeIotApi.Controllers
{
    [ApiController]
    [Route("api/Sensor")]
    [Produces("application/json")]
    public class SensorController : ControllerBase
    {
        private readonly ILogger<SensorController> _logger;

        private SQLiteDBContext _context { get; set; }

        public SensorController(ILogger<SensorController> logger, SQLiteDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: api/sensor
        [HttpGet]
        public IEnumerable<Sensor> Get()
        {
            return _context.Sensors.ToList();
        }

        // GET api/sensor/5
        [HttpGet("{id}")]
        public Sensor Get(int id)
        {
            return _context.Sensors.FirstOrDefault(s => s.Id == id);
        }

        // POST api/sensor
        [HttpPost]
        public void Post([FromBody]Sensor sensor)
        {
            _context.Sensors.Add(sensor);
            _context.SaveChanges();
        }

        // PUT api/sensor/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Sensor sensor)
        {
            _context.Sensors.Update(sensor);
            _context.SaveChanges();
        }

        // DELETE api/sensor/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var sensor = _context.Sensors.FirstOrDefault(t => t.Id == id);
            if (sensor != null)
            {
                _context.Sensors.Remove(sensor);
                _context.SaveChanges();
            }
        }

    }
}
