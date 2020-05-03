using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValeIotApi;
using ValeIotApi.Entities;

namespace IotAPIFrameWork.Controllers
{
    [Route("api/SensorTolerances")]
    [ApiController]
    public class SensorTolerancesController : ControllerBase
    {
        private readonly SQLiteDBContext _context;

        public SensorTolerancesController(SQLiteDBContext context)
        {
            _context = context;
        }

        // GET: api/SensorTolerances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorTolerance>>> GetSensorTolerances()
        {
            return await _context.SensorTolerances.ToListAsync();
        }

        // GET: api/SensorTolerances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SensorTolerance>> GetSensorTolerance(long id)
        {
            var sensorTolerance = await _context.SensorTolerances.FindAsync(id);

            if (sensorTolerance == null)
            {
                return NotFound();
            }

            return sensorTolerance;
        }

        // PUT: api/SensorTolerances/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensorTolerance(long id, SensorTolerance sensorTolerance)
        {
            if (id != sensorTolerance.Id)
            {
                return BadRequest();
            }

            _context.Entry(sensorTolerance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorToleranceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SensorTolerances
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SensorTolerance>> PostSensorTolerance(SensorTolerance sensorTolerance)
        {
            _context.SensorTolerances.Add(sensorTolerance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSensorTolerance", new { id = sensorTolerance.Id }, sensorTolerance);
        }

        // DELETE: api/SensorTolerances/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SensorTolerance>> DeleteSensorTolerance(long id)
        {
            var sensorTolerance = await _context.SensorTolerances.FindAsync(id);
            if (sensorTolerance == null)
            {
                return NotFound();
            }

            _context.SensorTolerances.Remove(sensorTolerance);
            await _context.SaveChangesAsync();

            return sensorTolerance;
        }

        private bool SensorToleranceExists(long id)
        {
            return _context.SensorTolerances.Any(e => e.Id == id);
        }
    }
}
