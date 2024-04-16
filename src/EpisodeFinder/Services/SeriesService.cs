using System.Text.RegularExpressions;
using EpisodeFinder.Database;
using EpisodeFinder.Database.Entities;
using Microsoft.EntityFrameworkCore;
using TMDbLib.Client;

namespace EpisodeFinder.Services;

public class SeriesService
{
    private ILogger<SeriesService> _logger;
    private PlexService _plexService;
    private readonly IDbContextFactory<EpisodeFinderContext> _dbContextFactory;

    public SeriesService(PlexService plexService, IDbContextFactory<EpisodeFinderContext> dbContextFactory, ILogger<SeriesService> logger)
    {
        _plexService = plexService;
        _dbContextFactory = dbContextFactory;
        _logger = logger;
    }

    public async Task<List<Series>> GetAllSeries()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.Series.ToListAsync();
    }

    public async Task<Series?> GetSeriesData(int id)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.Series
            .Include(s => s.Seasons)
            .ThenInclude(s => s.Episodes)
            .Where(s => s.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task SetMonitoring(int seasonId, bool monitoring)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        await context.Seasons
            .Where(s => s.Id == seasonId)
            .ExecuteUpdateAsync(p => 
                p.SetProperty(s => s.Monitoring, monitoring));
    }

    public async Task GetMissingAndMonitoredEpisodes()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var episodes = await context.Episodes
            .Include(e => e.Season)
            .Where(e => e.Season.Monitoring)
            .Where(e => e.PlexRatingKey == null)
            .Select(e => new
            {
                Title = e.Title,
                SeasonNumber = e.Season.SeasonNumber,
                EpisodeNumber = e.EpisodeNumber
            })
            .ToListAsync();
        _logger.LogInformation("{}", episodes.Count);
    }

}