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
    [Route("api/MeasurementTypes")]
    [ApiController]
    public class MeasurementTypesController : ControllerBase
    {
        private readonly SQLiteDBContext _context;

        public MeasurementTypesController(SQLiteDBContext context)
        {
            _context = context;
        }

        // GET: api/MeasurementTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeasurementType>>> GetMeasurementTypes()
        {
            return await _context.MeasurementTypes.ToListAsync();
        }

        // GET: api/MeasurementTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeasurementType>> GetMeasurementType(long id)
        {
            var measurementType = await _context.MeasurementTypes.FindAsync(id);

            if (measurementType == null)
            {
                return NotFound();
            }

            return measurementType;
        }

        // PUT: api/MeasurementTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeasurementType(long id, MeasurementType measurementType)
        {
            if (id != measurementType.Id)
            {
                return BadRequest();
            }

            _context.Entry(measurementType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeasurementTypeExists(id))
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

        // POST: api/MeasurementTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MeasurementType>> PostMeasurementType(MeasurementType measurementType)
        {
            _context.MeasurementTypes.Add(measurementType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeasurementType", new { id = measurementType.Id }, measurementType);
        }

        // DELETE: api/MeasurementTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MeasurementType>> DeleteMeasurementType(long id)
        {
            var measurementType = await _context.MeasurementTypes.FindAsync(id);
            if (measurementType == null)
            {
                return NotFound();
            }

            _context.MeasurementTypes.Remove(measurementType);
            await _context.SaveChangesAsync();

            return measurementType;
        }

        private bool MeasurementTypeExists(long id)
        {
            return _context.MeasurementTypes.Any(e => e.Id == id);
        }
    }
}
