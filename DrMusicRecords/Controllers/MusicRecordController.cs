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
        public void Post([FromBody] MusicRecords value)
        {
            Records.Add(value);
        }

        // PUT: api/MusicRecord/Artist
        [HttpPut("{id}")]
        public void Put(string artistAndTitle, [FromBody] MusicRecords value)
        {
            MusicRecords recordArtist = GetArtistSubString(artistAndTitle);
            MusicRecords recordTitle = GetTitleSubString(artistAndTitle);

            if (recordArtist != null)
            {
                recordArtist.Duration = value.Duration;
                recordArtist.Artist = value.Artist;
                recordArtist.Title = value.Title;
                recordArtist.YearOfPublication = value.YearOfPublication;
            }

            if (recordTitle != null)
            {
                recordTitle.Duration = value.Duration;
                recordTitle.Artist = value.Artist;
                recordTitle.Title = value.Title;
                recordTitle.YearOfPublication = value.YearOfPublication;
            }
        }

        // PUT: api/MusicRecord/Duration
        [HttpPut("{id}")]
        public void Put(int durationAndYear , [FromBody] MusicRecords value)
        {
            MusicRecords recordDuration = GetDurationSubString(durationAndYear);
            MusicRecords recordsYear = GetyearOfPublicationSubString(durationAndYear);

            if (recordDuration != null)
            {
                recordDuration.Duration = value.Duration;
                recordDuration.Artist = value.Artist;
                recordDuration.Title = value.Title;
                recordDuration.YearOfPublication = value.YearOfPublication;
            }

            if (recordsYear != null)
            {
                recordsYear.Duration = value.Duration;
                recordsYear.Artist = value.Artist;
                recordsYear.Title = value.Title;
                recordsYear.YearOfPublication = value.YearOfPublication;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
