using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jobdetailsApiDb.Models;

namespace jobdetailsApiDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobDetailsController : ControllerBase
    {
        private readonly jobdbContext _context;

        public JobDetailsController(jobdbContext context)
        {
            _context = context;
        }

        // GET: api/JobDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDetail>>> GetJobDetails()
        {
            return await _context.JobDetails.ToListAsync();
        }

        // GET: api/JobDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobDetail>> GetJobDetail(int id)
        {
            var jobDetail = await _context.JobDetails.FindAsync(id);

            if (jobDetail == null)
            {
                return NotFound();
            }

            return jobDetail;
        }

        // PUT: api/JobDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobDetail(int id, JobDetail jobDetail)
        {
            if (id != jobDetail.JobDetailsId)
            {
                return BadRequest();
            }

            _context.Entry(jobDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobDetailExists(id))
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

        // POST: api/JobDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobDetail>> PostJobDetail(JobDetail jobDetail)
        {
            _context.JobDetails.Add(jobDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobDetail", new { id = jobDetail.JobDetailsId }, jobDetail);
        }

        // DELETE: api/JobDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobDetail(int id)
        {
            var jobDetail = await _context.JobDetails.FindAsync(id);
            if (jobDetail == null)
            {
                return NotFound();
            }

            _context.JobDetails.Remove(jobDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobDetailExists(int id)
        {
            return _context.JobDetails.Any(e => e.JobDetailsId == id);
        }
    }
}
