using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ValeIotApi.Entities;

namespace ValeIotApi.Controllers
{
    [ApiController]
    [Route("api/Sensors")]
    [Produces("application/json")]
    public class SensorsController : ControllerBase
    {
        private readonly ILogger<SensorsController> _logger;

        private SQLiteDBContext _context { get; set; }

        public SensorsController(ILogger<SensorsController> logger, SQLiteDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: api/sensor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sensor>>> Get()
        {

            return await _context.Sensors
                            .Include(l => l.Location)
                            .Include(m => m.MeasurementTypes)
                            .Include(d => d.Device)
                            .ToListAsync();
        }

        // GET api/sensor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sensor>> Get(int id)
        {
            return await _context.Sensors
                   .Include(l => l.Location)
                   .Include(d => d.Device)
                   .Include(m  => m.MeasurementTypes)
                   .FirstOrDefaultAsync(s => s.Id == id);
        }

        // POST api/sensor
        [HttpPost]
        public async void Post([FromBody]Sensor sensor)
        {
            _context.Sensors.Add(sensor);
           await _context.SaveChangesAsync();
        }

        // PUT api/sensor/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody]Sensor sensor)
        {
            _context.Sensors.Update(sensor);
           await _context.SaveChangesAsync();
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
