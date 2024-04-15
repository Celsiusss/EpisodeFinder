using System.Text.RegularExpressions;
using EpisodeFinder.Database;
using EpisodeFinder.Database.Entities;
using Microsoft.EntityFrameworkCore;
using TMDbLib.Client;

namespace EpisodeFinder.Services;

public class SeriesService
{

    private PlexService _plexService;
    private readonly IDbContextFactory<EpisodeFinderContext> _dbContextFactory;

    public SeriesService(PlexService plexService, IDbContextFactory<EpisodeFinderContext> dbContextFactory)
    {
        _plexService = plexService;
        _dbContextFactory = dbContextFactory;
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



}