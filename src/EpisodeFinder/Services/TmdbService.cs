using EpisodeFinder.Database;
using EpisodeFinder.Database.Entities;
using Microsoft.EntityFrameworkCore;
using TMDbLib.Client;
using TMDbLib.Objects.Find;
using TMDbLib.Objects.TvShows;

namespace EpisodeFinder.Services;

public class TmdbService
{
    private readonly ILogger<TmdbService> _logger;
    private readonly IDbContextFactory<EpisodeFinderContext> _dbContextFactory;
    private readonly TMDbClient _tmdbClient;

    public TmdbService(IDbContextFactory<EpisodeFinderContext> dbContextFactory, ILogger<TmdbService> logger, IConfiguration configuration)
    {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
        _tmdbClient = new TMDbClient(configuration["TmdbApiKey"]);
    }

    public async Task FillData()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        _logger.LogDebug("Start TMDB data fill");
        
        var allSeries = await context.Series.ToListAsync();
        foreach (var seriesEntity in allSeries)
        {
            var hasTmdb = int.TryParse(seriesEntity.TmdbId, out var tmdbId);
            _logger.LogDebug("Processing {title} with ID {id}", seriesEntity.Title, seriesEntity.Id);
            TvShow series;
            if (hasTmdb)
            {
                series = await _tmdbClient.GetTvShowAsync(tmdbId);
            } else if (seriesEntity.ImdbId != null)
            {
                var result = await _tmdbClient.FindAsync(FindExternalSource.Imdb, seriesEntity.ImdbId);
                var id = result.TvResults.FirstOrDefault()?.Id;
                if (id == null) continue;
                series = await _tmdbClient.GetTvShowAsync((int)id);
            }
            else
            {
                _logger.LogDebug("Series has no tmdb or imdb ID, series ID: {id}", seriesEntity.Id);
                continue;
            };

            await UpdateSeasons(seriesEntity, series, context);
        }
        _logger.LogDebug("Done processing TMDB");
    }

    private async Task UpdateSeasons(Series seriesEntity, TvShow series, EpisodeFinderContext context)
    {
        var hasTmdb = int.TryParse(seriesEntity.TmdbId, out var tmdbId);
        if (!hasTmdb) return;

        for (var seasonNumber = 1; seasonNumber <= series.NumberOfSeasons; seasonNumber++)
        {
            _logger.LogDebug("Processing season {season}", seasonNumber);
            var season = await _tmdbClient.GetTvSeasonAsync(tmdbId, seasonNumber);

            var seasonEntity = await context.Seasons
                .Where(s => s.SeriesId == seriesEntity.Id && s.SeasonNumber == seasonNumber)
                .FirstOrDefaultAsync() 
                               ?? new Season()
                               {
                                   SeriesId = seriesEntity.Id,
                                   SeasonNumber = seasonNumber,
                                   SeasonName = season.Name
                               };
            context.Update(seasonEntity);
            await context.SaveChangesAsync();
            
            foreach (var episode in season.Episodes)
            {
                _logger.LogDebug("Processing episode {episode}", episode.EpisodeNumber);
                var episodeEntity = await context.Episodes.Where(e =>
                    e.SeasonId == seasonEntity.Id &&
                    e.EpisodeNumber == episode.EpisodeNumber
                ).FirstOrDefaultAsync()
                    ?? new Episode()
                    {
                        SeasonId = seasonEntity.Id,
                        EpisodeNumber = episode.EpisodeNumber,
                        Title = episode.Name
                    };
                context.Update(episodeEntity);
            }
            await context.SaveChangesAsync();
        }
    }
}