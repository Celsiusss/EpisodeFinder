using EpisodeFinder.Models;

namespace EpisodeFinder.Services;

public class TorznabService
{

    private readonly HttpClient _http;
    private readonly SeriesService _seriesService;

    public TorznabService(HttpClient http, SeriesService seriesService)
    {
        _http = http;
        _seriesService = seriesService;
    }

    public async Task ReadFeed()
    {
        var stream = await _http.GetStreamAsync("http://192.168.1.100:9117/api/v2.0/indexers/beyond-hd-api/results/torznab/api?apikey=yh42c04s71ulyyxfavan8cb5ek72jam5&t=search&cat=&q=");
        var feed = Helpers.Deserialize<Torznab.Rss>(stream);
        await _seriesService.GetMissingAndMonitoredEpisodes();

    }
}