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
    [Route("api/{sensorId}/{sensorMeasurementId}/SensorMeasurement")]
    public class SensorMeasurementController : ControllerBase
    {
        private readonly ILogger<SensorMeasurementController> _logger;

        private SQLiteDBContext _context { get; set; }

        public SensorMeasurementController(ILogger<SensorMeasurementController> logger, SQLiteDBContext context)
        {
            _logger = logger;
            _context = context;
        }
                
        [HttpGet]
        public IEnumerable<SensorMeasurement> Get([FromRoute]long sensorId, [FromRoute]long sensorMeasurementId)
        {
            return _context.SensorMeasurements.Where(p => p.SensorId == sensorId && p.MeasurementTypeId == sensorMeasurementId)
                    .Include(s => s.Sensor)
                    .Include(Mt => Mt.MeasurementType);
                 
        }


        [HttpPost]
        public void Post([FromBody]SensorMeasurement sensorData)
        {
            _context.SensorMeasurements.Add(sensorData);
            _context.SaveChanges();
        }

    }
}
