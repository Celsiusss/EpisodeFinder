using System.Text.RegularExpressions;

namespace EpisodeFinder;

public static class Helpers
{
    public static KeyValuePair<string, string> ExtractGuid(string guid)
    {
        var pattern = @"(.+):\/\/(.+)";
        var match = Regex.Match(guid, pattern);
        var key = match.Groups[1].Value;
        var value = match.Groups[2].Value;
        return new KeyValuePair<string, string>(key, value);
    }
}
