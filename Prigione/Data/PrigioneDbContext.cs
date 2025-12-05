using Microsoft.EntityFrameworkCore;
using Prigione.Models;

namespace Prigione.Data
{
    public class PrigioneDbContext : DbContext
    {
        public PrigioneDbContext(DbContextOptions<PrigioneDbContext> options) : base(options)
        {
        }
        public DbSet<TrasgressoreModel> Trasgressori { get; set; }
        public DbSet<ViolazioneModel> Violazioni { get; set; }
        public DbSet<VerbaleModel> Verbali { get; set; }
    }
}
