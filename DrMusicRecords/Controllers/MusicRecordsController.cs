using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DrMusicRecords.Models;

namespace DrMusicRecords.Controllers
{
    [Route("api/DB/[controller]")]
    [ApiController]
    public class MusicRecordsController : ControllerBase
    {
        private readonly MusicRecordsContext _context;

        public MusicRecordsController(MusicRecordsContext context)
        {
            _context = context;

            addInitRecords();
        }

        private async void addInitRecords()
        {
            _context.MusicRecordsList.Add(new MusicRecords("Titles", "Artist1", 220, 1986));
            _context.MusicRecordsList.Add(new MusicRecords("Titles", "Artister", 201, 1910));
            _context.MusicRecordsList.Add(new MusicRecords("TitlesOther", "Artist2", 260, 10));
            _context.MusicRecordsList.Add(new MusicRecords("TitlesNew", "Artist3", 280, 1960));
            await _context.SaveChangesAsync();
        }
        // GET: api/MusicRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicRecordsDTO>>> GetMusicRecordsList()
        {
            return await _context.MusicRecordsList
                .Select(x => RecordsToDTO(x))
                .ToListAsync();
        }

        // GET: api/MusicRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MusicRecordsDTO>> GetMusicRecords(int id)
        {
            var musicRecords = await _context.MusicRecordsList.FindAsync(id);

            if (musicRecords == null)
            {
                return NotFound();
            }

            return RecordsToDTO(musicRecords);
        }

        // PUT: api/MusicRecords/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusicRecords(int id, MusicRecordsDTO musicRecordsDTO)
        {
            if (id != musicRecordsDTO.Id)
            {
                return BadRequest();
            }

            var todoRecords = await _context.MusicRecordsList.FindAsync(id);
            if (todoRecords == null)
            {
                return NotFound();
            }

            todoRecords.Title = musicRecordsDTO.Title;
            todoRecords.Duration = musicRecordsDTO.Duration;
            todoRecords.Artist = musicRecordsDTO.Artist;
            todoRecords.YearOfPublication = musicRecordsDTO.YearOfPublication;

            _context.Entry(musicRecordsDTO).State = EntityState.Modified;

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
        public async Task<ActionResult<MusicRecords>> PostMusicRecords(MusicRecordsDTO musicRecordsDTO)
        {
            var todoRecords = new MusicRecords
            {
                Artist = musicRecordsDTO.Artist,
                Title = musicRecordsDTO.Title,
                Duration = musicRecordsDTO.Duration,
                YearOfPublication = musicRecordsDTO.YearOfPublication
            };

            _context.MusicRecordsList.Add(todoRecords);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusicRecords", new {id = todoRecords.Id}, RecordsToDTO(todoRecords));
        }

        // DELETE: api/MusicRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusicRecords(int id)
        {
            var todoRecords = await _context.MusicRecordsList.FindAsync(id);
            if (todoRecords == null)
            {
                return NotFound();
            }

            _context.MusicRecordsList.Remove(todoRecords);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusicRecordsExists(int id)
        {
            return _context.MusicRecordsList.Any(e => e.Id == id);
        }

        private static MusicRecordsDTO RecordsToDTO(MusicRecords musicRecords) => new MusicRecordsDTO
        {
            Id = musicRecords.Id,
            Duration = musicRecords.Duration,
            YearOfPublication = musicRecords.YearOfPublication,
            Artist = musicRecords.Artist,
            Title = musicRecords.Title
        };
    }
}
