using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_Controllers.Entities;

namespace SuperHeroAPI_Controllers.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
   