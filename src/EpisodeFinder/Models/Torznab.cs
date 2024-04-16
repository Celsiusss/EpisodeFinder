using System.Xml.Serialization;

namespace EpisodeFinder.Models;

public class Torznab
{
    [XmlRoot(ElementName = "rss")]
    public class Rss
    {
        [XmlElement(ElementName = "channel")]
        public Channel? Channel { get; set; }
    }

    [XmlRoot(ElementName = "channel")]
    public class Channel
    {
        [XmlElement(ElementName = "category")]
        public string? Category { get; set; }
        [XmlElement(ElementName = "language")]
        public string? Language { get; set; }
        [XmlElement(ElementName = "item")]
        public Item[] Items { get; set; } = [];
    }
    
    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlElement(ElementName = "title")]
        public string? Title { get; set; }
        [XmlElement(ElementName = "guid")]
        public string? Guid { get; set; }
        [XmlElement(ElementName = "datePub")]
        public string? DatePub { get; set; }
        [XmlElement("size")]
        public long? Size { get; set; }
        [XmlElement("torznab:attr")]
        public TorznabAttribute[] TorznabAttributes { get; set; } = [];
    }
    
    [XmlRoot(ElementName = "enclosure")]
    public class Enclosure {
        [XmlAttribute(AttributeName = "url")]
        public string? Url { get; set; }
        [XmlAttribute(AttributeName = "length")]
        public long? Length { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string? Type { get; set; }
    }

    [XmlRoot(ElementName = "torznab:attr")]
    public class TorznabAttribute
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}