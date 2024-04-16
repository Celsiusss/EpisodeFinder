using System.Xml.Serialization;
using EpisodeFinder.Database;
using EpisodeFinder.Database.Entities;
using EpisodeFinder.Models.Plex;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace EpisodeFinder.Services;

public class PlexService
{
    private readonly ILogger<PlexService> _logger;
    private readonly HttpClient _http;
    private readonly IDbContextFactory<EpisodeFinderContext> _dbContextFactory;

    private readonly string _plexUrl;

    public PlexService(HttpClient httpClient, IDbContextFactory<EpisodeFinderContext> dbContextFactory, IConfiguration configuration, ILogger<PlexService> logger)
    {
        httpClient.DefaultRequestHeaders.Add("X-Plex-Token", configuration["PlexToken"]);
        _http = httpClient;
        _dbContextFactory = dbContextFactory;
        _logger = logger;
        _plexUrl = configuration["PlexUrl"];
    }

    public async Task ScanLibrary()
    {
        await using var  context = await _dbContextFactory.CreateDbContextAsync();
        _logger.LogDebug("Started library scan");

        var seriesList = (await GetAllSeries()).Directory;
        foreach (var series in seriesList)
        {
            if (series.Type != "show") continue;
            _logger.LogDebug("Processing {title}", series.Title);

            var seriesMeta = await GetMetadata(series.RatingKey);
            var guids = seriesMeta.Directories[0].Guids
                .Select(g => Helpers.ExtractGuid(g.Id))
                .Where(g => g.Key != "tvdb")
                .ToDictionary();
            var hasImdb = guids.TryGetValue("imdb", out var imdbId);
            var hasTmdb = guids.TryGetValue("tmdb", out var tmdbId);

            var seriesEntity = await context.Series
                                   .Include(s => s.Seasons)
                                   .ThenInclude(s => s.Episodes)
                                   .Where(s => s.ImdbId == imdbId || s.TmdbId == tmdbId).FirstOrDefaultAsync()
                               ?? new Series() { Title = series.Title };
            seriesEntity.PlexRatingKey = series.RatingKey;
            seriesEntity.ImdbId ??= imdbId;
            seriesEntity.TmdbId ??= tmdbId;
            context.Update(seriesEntity);
            await context.SaveChangesAsync();
            await ScanSeasons(seriesEntity, context);
        }
        _logger.LogDebug("Finished library scan");

    }

    private async Task ScanSeasons(Series seriesEntity, EpisodeFinderContext context)
    {
        if (seriesEntity.PlexRatingKey == null) return;
        var children = await GetChildren(seriesEntity.PlexRatingKey);
        foreach (var season in children.Directories)
        {
            if (season.Type != "season") continue;
            _logger.LogDebug("Processing {season}", season.Title);
            var seasonNumber = int.TryParse(season.Index, out var val) ? val : -1;
            if (seasonNumber == -1) continue;
            var seasonEntity = seriesEntity.Seasons.FirstOrDefault(s => s.SeasonNumber == seasonNumber) 
                               ?? new Season()
                               {
                                   SeriesId = seriesEntity.Id,
                                   SeasonNumber = seasonNumber,
                                   SeasonName = season.Title
                               };
            seasonEntity.PlexRatingKey = season.RatingKey;
            context.Update(seasonEntity);
            await context.SaveChangesAsync();
            await ScanEpisodes(seasonEntity, context);
        }
    }

    private async Task ScanEpisodes(Season seasonEntity, EpisodeFinderContext context)
    {
        if (seasonEntity.PlexRatingKey == null) return;
        var children = await GetChildren(seasonEntity.PlexRatingKey);
        foreach (var episode in children.Videos)
        {
            if (episode.Type != "episode") continue;
            _logger.LogDebug("Processing {episode}", episode.Title);
            var episodeNumber = episode.Index;
            var episodeEntity = seasonEntity.Episodes.FirstOrDefault(e => e.EpisodeNumber == episodeNumber)
                ?? new Episode()
                {
                    Title = episode.Title,
                    SeasonId = seasonEntity.Id,
                    EpisodeNumber = episodeNumber
                };
            episodeEntity.PlexRatingKey = episode.RatingKey;
            context.Update(episodeEntity);
        }
        await context.SaveChangesAsync();
    }
    
    public async Task<string> FindMatch(string title)
    {
        var queryString = QueryString.Create(
                [
                    new KeyValuePair<string, StringValues>("manual", "1"),
                    new KeyValuePair<string, StringValues>("title", title)
                ]
            );
        var res = await _http.GetAsync($"{_plexUrl}/library/metadata/17352/matches" + queryString);
        var obj = Helpers.Deserialize<MatchResult.MediaContainer>(await res.Content.ReadAsStreamAsync());

        if (obj.SearchResultList.Count == 0)
        {
            return string.Empty;
        }
        return obj.SearchResultList[0].Name ?? string.Empty;
    }

    public async Task<LibrarySection.MediaContainer> GetAllSeries()
    {
        var stream = await _http.GetStreamAsync($"{_plexUrl}/library/sections/6/all");
        var obj = Helpers.Deserialize<LibrarySection.MediaContainer>(stream);
        return obj;
    }

    public async Task<Metadata.MediaContainer> GetMetadata(string ratingKey)
    {
        var stream = await _http.GetStreamAsync($"{_plexUrl}/library/metadata/{ratingKey}");
        var obj = Helpers.Deserialize<Metadata.MediaContainer>(stream);
        return obj;
    }

    public async Task<Metadata.MediaContainer> GetChildren(string ratingKey)
    {
        var stream = await _http.GetStreamAsync($"{_plexUrl}/library/metadata/{ratingKey}/children");
        var obj = Helpers.Deserialize<Metadata.MediaContainer>(stream);
        return obj;
    }

}
