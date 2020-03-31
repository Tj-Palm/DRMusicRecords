using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DrMusicRecords.Models;

namespace DrMusicRecords.Controllers
{
    [Route("api/test/[controller]")]
    [ApiController]
    public class MusicRecordsController : ControllerBase
    {
        private readonly MusicRecordsContext _context;

        public MusicRecordsController(MusicRecordsContext context)
        {
            _context = context;

            _context.MusicRecordsList.Add(new MusicRecords( "Titles", "Artist1", 220, 1986));
            _context.MusicRecordsList.Add(new MusicRecords( "Titles", "Artister", 201, 1910));
            _context.MusicRecordsList.Add(new MusicRecords( "TitlesSomething", "Artist2", 210, 180));
            _context.MusicRecordsList.Add(new MusicRecords( "TitlesOther", "Artist2", 260, 10));
            _context.MusicRecordsList.Add(new MusicRecords( "TitlesNew", "Artist3", 280, 1960));
        }

        // GET: api/MusicRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicRecords>>> GetMusicRecordsList()
        {
            return await _context.MusicRecordsList.ToListAsync();
        }

        // GET: api/MusicRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MusicRecords>> GetMusicRecords(int id)
        {
            var musicRecords = await _context.MusicRecordsList.FindAsync(id);

            if (musicRecords == null)
            {
                return NotFound();
            }

            return musicRecords;
        }

        // PUT: api/MusicRecords/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusicRecords(int id, MusicRecords musicRecords)
        {
            if (id != musicRecords.Id)
            {
                return BadRequest();
            }

            _context.Entry(musicRecords).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicRecordsExists(id))
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

        // POST: api/MusicRecords
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MusicRecords>> PostMusicRecords(MusicRecords musicRecords)
        {
            _context.MusicRecordsList.Add(musicRecords);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusicRecords", new { id = musicRecords.Id }, musicRecords);
        }

        // DELETE: api/MusicRecords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MusicRecords>> DeleteMusicRecords(int id)
        {
            var musicRecords = await _context.MusicRecordsList.FindAsync(id);
            if (musicRecords == null)
            {
                return NotFound();
            }

            _context.MusicRecordsList.Remove(musicRecords);
            await _context.SaveChangesAsync();

            return musicRecords;
        }

        private bool MusicRecordsExists(int id)
        {
            return _context.MusicRecordsList.Any(e => e.Id == id);
        }
    }
}
