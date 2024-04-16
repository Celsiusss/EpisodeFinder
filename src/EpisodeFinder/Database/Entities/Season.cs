namespace EpisodeFinder.Database.Entities;

public class Season
{
    public int Id { get; set; }
    public string? PlexRatingKey { get; set; }
    public int SeasonNumber { get; set; }
    public string? SeasonName { get; set; }
    public bool Monitoring { get; set; } = false;
    public ICollection<Episode> Episodes { get; set; } = [];
    
    public int SeriesId { get; set; }
    public Series Series { get; set; }
}
