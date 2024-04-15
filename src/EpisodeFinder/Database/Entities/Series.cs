namespace EpisodeFinder.Database.Entities;

public class Series
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    public string? PlexRatingKey { get; set; }
    public string? ImdbId { get; set; }
    public string? TmdbId { get; set; }

    public ICollection<Season> Seasons { get; set; } = [];
}
