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
    [Route("api/SensorTolerance")]
    [Produces("application/json")]
    public class SensorToleranceController : ControllerBase
    {
        private readonly ILogger<SensorToleranceController> _logger;

        private SQLiteDBContext _context { get; set; }

        public SensorToleranceController(ILogger<SensorToleranceController> logger, SQLiteDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: api/sensor
        [HttpGet]
        public IEnumerable<SensorTolerance> Get()
        {
            return _context.SensorTolerances.ToList();
        }

        // GET api/sensor/5
        [HttpGet("{id}")]
        public SensorTolerance Get(int id)
        {
            return _context.SensorTolerances.FirstOrDefault(s => s.Id == id);
        }

        // POST api/sensor
        [HttpPost]
        public void Post([FromBody]SensorTolerance sensor)
        {
            _context.SensorTolerances.Add(sensor);
            _context.SaveChanges();
        }

        // PUT api/sensor/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]SensorTolerance sensor)
        {
            _context.SensorTolerances.Update(sensor);
            _context.SaveChanges();
        }

        // DELETE api/sensor/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var sensor = _context.SensorTolerances.FirstOrDefault(t => t.Id == id);
            if (sensor != null)
            {
                _context.SensorTolerances.Remove(sensor);
                _context.SaveChanges();
            }
        }

    }
}
