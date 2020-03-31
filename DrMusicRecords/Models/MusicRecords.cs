using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrMusicRecords.Models
{
    public class MusicRecords
    {


        public string Title { get; set; }
        public string Artist { get; set; }
        public int Duration { get; set; }
        public int YearOfPublication { get; set; }
        public int Id { get; set; }

        public MusicRecords()
        {

        }

        public MusicRecords(int id, string title, string artist, int duration, int yearOfPublication)
        {
            Id = id;
            Title = title;
            Artist = artist;
            Duration = duration;
            YearOfPublication = yearOfPublication;
        }

    }
}



