using System.Text.RegularExpressions;
using System.Xml.Serialization;

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
    
    public static T Deserialize<T>(Stream response)
    {
        var serializer = new XmlSerializer(typeof(T));
        var obj = serializer.Deserialize(response);
        if (obj == null)
        {
            throw new ApplicationException("Could not deserialize response of type " + typeof(T));
        }

        return (T)obj;
    }

}
