using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DrMusic;

namespace DrMusicRecords.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicRecordController : ControllerBase
    {

        private static readonly List<MusicRecords> Records = new List<MusicRecords>()
        {
            new MusicRecords("Title", "Artist", 20, 1980),
            new MusicRecords("Title", "Artist", 30, 1970),
            new MusicRecords("Title", "Artist", 40, 1960),
            new MusicRecords("Title", "Artist", 20, 1990),

        };

        // GET: api/MusicRecord
        [HttpGet]
        public IEnumerable<MusicRecords> Get()
        {
            return Records;
        }

        // GET: api/MusicRecord/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return Records.Find(i => i.Title == Title || i => i.Artist == Artist);
        //}

        // POST: api/MusicRecord
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/MusicRecord/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
