using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DrMusic;

namespace DrMusicRecords.Models
{
    public class MusicRecordsContext : DbContext
    {
        public MusicRecordsContext(DbContextOptions<MusicRecordsContext> options):base(options)
        {
            
        }

        public DbSet<MusicRecords> MusicRecordsList { get; set; }
    }
}