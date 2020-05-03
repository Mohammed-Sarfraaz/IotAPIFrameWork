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
    [Route("api/{sensorId}/{measurementTypeId}/SensorMeasurements")]
    [Produces("application/json")]
    public class SensorMeasurementsController : ControllerBase
    {
        private readonly ILogger<SensorMeasurementsController> _logger;

        private SQLiteDBContext _context { get; set; }

        public SensorMeasurementsController(ILogger<SensorMeasurementsController> logger, SQLiteDBContext context)
        {
            _logger = logger;
            _context = context;
        }
                
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorMeasurement>>> Get([FromRoute]long sensorId, [FromRoute]long measurementTypeId)
        {
            return await _context.SensorMeasurements.Where(p => p.SensorId == sensorId && p.MeasurementTypeId == measurementTypeId)
                    .Include(s => s.Sensor)
                    .Include(Mt => Mt.MeasurementType).ToListAsync();                  
        }


        [HttpPost]
        public async void Post([FromBody]SensorMeasurement sensorData)
        {
            _context.SensorMeasurements.Add(sensorData);
            await _context.SaveChangesAsync();
        }

    }
}
