using EpisodeFinder.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace EpisodeFinder.Database;

public class EpisodeFinderContext : DbContext
{
    public DbSet<Series> Series { get; set; }
    public DbSet<Season> Seasons { get; set; }
    public DbSet<Episode> Episodes { get; set; }
    
    public EpisodeFinderContext(DbContextOptions<EpisodeFinderContext> options) : base(options)
    { }
    
    
}
