using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DrMusic;
using Newtonsoft.Json;

namespace DrMusicRecords.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicRecordController : ControllerBase
    {

        private static readonly List<MusicRecords> Records = new List<MusicRecords>()
        {
            new MusicRecords(1,"Titles", "Artist", 20, 1980),
            new MusicRecords(2,"Title1", "Artist1", 30, 1970),
            new MusicRecords(3,"Title2", "Artist2", 40, 1960),
            new MusicRecords(4,"Title3", "Artist3", 20, 1990),
        };

        // GET: api/MusicRecord
        [HttpGet]
        public IEnumerable<MusicRecords> Get()
        {
            return Records;
        }
        //GET: api/MusiciRecord/Id
        [HttpGet ("{id}")]
        public MusicRecords GetById(int id)
        {
            return Records.Find(i => i.Id == id);
        }

        //GET: api/MusicRecord/id
        [HttpGet("{id}")]
        public IEnumerable<MusicRecords> GetListById(int id)
        {
            var newList = Records.Find(i => i.Id == id);
            yield return newList;
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
        [Route("Artist/{substring}")]
        public MusicRecords GetArtistSubString(string substring)
        {
            return Records.Find(i => i.Artist == substring);
        }
        ///GET: api/MusicRecords/Duration/Duration
        [HttpGet]
        [Route("Duration/{substring}")]
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
        public void Post([FromBody] MusicRecords value)
        {
            Records.Add(value);
        }

        // PUT: api/Items/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MusicRecords value)
        {
            MusicRecords item = Get(id);
            if (item != null)
            {
                item.Title = value.Title;
                item.Artist = value.Artist;
                item.Duration = value.Duration;
                item.YearOfPublication = value.YearOfPublication;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            MusicRecords item = Get(id);
            Records.Remove(item);
        }
    }
}
