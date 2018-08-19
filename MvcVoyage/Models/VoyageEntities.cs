using System.Data.Entity;

namespace MvcVoyage.Models
{
    public class VoyageEntities : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<VoyageType> VoyageTypes { get; set; }
    }
}