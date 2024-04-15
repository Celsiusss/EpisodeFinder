using System.Xml.Serialization;

namespace EpisodeFinder.Models.Plex;

public class MatchResult
{
    [XmlRoot("MediaContainer")]
    public class MediaContainer
    {
        [XmlAttribute("size")]
        public int Size { get; set; }

        [XmlAttribute("identifier")]
        public string? Identifier { get; set; }

        [XmlAttribute("mediaTagPrefix")]
        public string? MediaTagPrefix { get; set; }

        [XmlAttribute("mediaTagVersion")]
        public long MediaTagVersion { get; set; }

        [XmlElement(ElementName = "SearchResult")]
        public List<SearchResult> SearchResultList { get; set; } = [];
    }

    public class SearchResult
    {
        [XmlAttribute("thumb")]
        public string? Thumb { get; set; }

        [XmlAttribute("type")]
        public string? Type { get; set; }

        [XmlAttribute("guid")]
        public string? Guid { get; set; }

        [XmlAttribute("name")]
        public string? Name { get; set; }

        [XmlAttribute("year")]
        public int Year { get; set; }

        [XmlAttribute("summary")]
        public string? Summary { get; set; }

        [XmlAttribute("lifespanEnded")]
        public int LifespanEnded { get; set; }
    }

}