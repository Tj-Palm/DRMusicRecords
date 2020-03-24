using System;

namespace DrMusic
{
    public class MusicRecords
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Duration { get; set; }
        public int YearOfPublication { get; set; }

        public MusicRecords()
        {
            
        }

        public MusicRecords(string title, string artist, int duration, int yearOfPublication)
        {
            Title = title;
            Artist = artist;
            Duration = duration;
            YearOfPublication = yearOfPublication;
        }

    }
}
