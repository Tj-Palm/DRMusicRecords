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
            new MusicRecords("Titles", "Artist", 20, 1980),
            new MusicRecords("Title1", "Artist", 30, 1970),
            new MusicRecords("Title2", "Artist", 40, 1960),
            new MusicRecords("Title3", "Artist", 20, 1990),
        };

        // GET: api/MusicRecord
        [HttpGet]
        public IEnumerable<MusicRecords> Get()
        {
            return Records;
        }
        //GET: api/MusicRecord/Title/Title
        [HttpGet]
        [Route("Title/{substring}")]
        public MusicRecords GetTitleSubString(string substring)
        {
            return Records.Find(i => i.Title == substring);
        }
        //GET: api/MusicRecords/Artist/Artist
        [HttpGet]
        [Route("Title/{substring}")]
        public MusicRecords GetArtistSubString(string substring)
        {
            return Records.Find(i => i.Artist == substring);
        }
        ///GET: api/MusicRecords/Duration/Duration
        [HttpGet]
        [Route("Title/{substring}")]
        public MusicRecords GetDurationSubString(int substring)
        {
            return Records.Find(i => i.Duration == substring);
        }
        //GET: api/MusicRecords/yearOfPublication/yop
        [HttpGet]
        [Route("yearOfPublication/{substring}")]
        public MusicRecords GetyearOfPublicationSubString(int substring)
        {
            return Records.Find(i => i.YearOfPublication == substring);
        }

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
