using EpisodeFinder.Components;
using EpisodeFinder.Database;
using EpisodeFinder.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<EpisodeFinderContext>(options =>
{
    var connectionStringBuilder = new SqliteConnectionStringBuilder()
    {
        DataSource = "database.db"
    };
    options.UseSqlite(connectionStringBuilder.ToString());
    options.EnableSensitiveDataLogging(true);
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<PlexService>();
builder.Services.AddScoped<SeriesService>();
builder.Services.AddScoped<TmdbService>();
builder.Services.AddScoped<TorznabService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();