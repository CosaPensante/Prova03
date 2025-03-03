using Microsoft.EntityFrameworkCore;

namespace ProvaAzure01.Data
{
    public class MeteoDbContext:DbContext
    {
        public MeteoDbContext() : base() { }
        public MeteoDbContext(DbContextOptions<MeteoDbContext> options) : base(options) { }

        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Citta> Citta { get; set; }
        public DbSet<CittaPreferita> CittaPreferite { get; set; }
    }
}
