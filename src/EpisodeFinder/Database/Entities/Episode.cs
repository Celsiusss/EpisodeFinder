namespace EpisodeFinder.Database.Entities;

public class Episode
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int EpisodeNumber { get; set; }
    public string? PlexRatingKey { get; set; }
    
    public int SeasonId { get; set; }
    public Season Season { get; set; }
}
