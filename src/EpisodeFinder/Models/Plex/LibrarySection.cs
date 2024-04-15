using System.Xml.Serialization;

namespace EpisodeFinder.Models.Plex;

public class LibrarySection
{
    [XmlRoot(ElementName = "Genre")]
    public class Genre
    {
        [XmlAttribute(AttributeName = "tag")]
        public string? Tag { get; set; }
    }

    [XmlRoot(ElementName = "Role")]
    public class Role
    {
        [XmlAttribute(AttributeName = "tag")]
        public string? Tag { get; set; }
    }

    [XmlRoot(ElementName = "Directory")]
    public class Directory
    {
        [XmlElement(ElementName = "Genre")]
        public List<Genre> GenreList { get; set; } = [];
        [XmlElement(ElementName = "Role")]
        public List<Role> RoleList { get; set; } = [];
        [XmlAttribute(AttributeName = "ratingKey")]
        public string? RatingKey { get; set; }
        [XmlAttribute(AttributeName = "key")]
        public string? Key { get; set; }
        [XmlAttribute(AttributeName = "guid")]
        public string? Guid { get; set; }
        [XmlAttribute(AttributeName = "slug")]
        public string? Slug { get; set; }
        [XmlAttribute(AttributeName = "studio")]
        public string? Studio { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string? Type { get; set; }
        [XmlAttribute(AttributeName = "title")]
        public string? Title { get; set; }
        [XmlAttribute(AttributeName = "contentRating")]
        public string? ContentRating { get; set; }
        [XmlAttribute(AttributeName = "summary")]
        public string? Summary { get; set; }
        [XmlAttribute(AttributeName = "index")]
        public string? Index { get; set; }
        [XmlAttribute(AttributeName = "audienceRating")]
        public string? AudienceRating { get; set; }
        [XmlAttribute(AttributeName = "year")]
        public string? Year { get; set; }
        [XmlAttribute(AttributeName = "tagline")]
        public string? Tagline { get; set; }
        [XmlAttribute(AttributeName = "thumb")]
        public string? Thumb { get; set; }
        [XmlAttribute(AttributeName = "art")]
        public string? Art { get; set; }
        [XmlAttribute(AttributeName = "theme")]
        public string? Theme { get; set; }
        [XmlAttribute(AttributeName = "duration")]
        public string? Duration { get; set; }
        [XmlAttribute(AttributeName = "originallyAvailableAt")]
        public string? OriginallyAvailableAt { get; set; }
        [XmlAttribute(AttributeName = "leafCount")]
        public string? LeafCount { get; set; }
        [XmlAttribute(AttributeName = "viewedLeafCount")]
        public string? ViewedLeafCount { get; set; }
        [XmlAttribute(AttributeName = "childCount")]
        public string? ChildCount { get; set; }
        [XmlAttribute(AttributeName = "addedAt")]
        public string? AddedAt { get; set; }
        [XmlAttribute(AttributeName = "updatedAt")]
        public string? UpdatedAt { get; set; }
        [XmlAttribute(AttributeName = "audienceRatingImage")]
        public string? AudienceRatingImage { get; set; }
        [XmlAttribute(AttributeName = "viewCount")]
        public string? ViewCount { get; set; }
        [XmlAttribute(AttributeName = "skipCount")]
        public string? SkipCount { get; set; }
        [XmlAttribute(AttributeName = "lastViewedAt")]
        public string? LastViewedAt { get; set; }
        [XmlAttribute(AttributeName = "lastRatedAt")]
        public string? LastRatedAt { get; set; }
        [XmlAttribute(AttributeName = "userRating")]
        public string? UserRating { get; set; }
        [XmlAttribute(AttributeName = "hasPremiumPrimaryExtra")]
        public string? HasPremiumPrimaryExtra { get; set; }
        [XmlAttribute(AttributeName = "primaryExtraKey")]
        public string? PrimaryExtraKey { get; set; }
        [XmlAttribute(AttributeName = "mediaTagPrefix")]
        public string? MediaTagPrefix { get; set; }
        [XmlAttribute(AttributeName = "mediaTagVersion")]
        public string? MediaTagVersion { get; set; }
        [XmlAttribute(AttributeName = "nocache")]
        public string? Nocache { get; set; }
        [XmlAttribute(AttributeName = "allowSync")]
        public string? AllowSync { get; set; }
        [XmlAttribute(AttributeName = "size")]
        public string? Size { get; set; }
        [XmlAttribute(AttributeName = "identifier")]
        public string? Identifier { get; set; }
        [XmlAttribute(AttributeName = "librarySectionID")]
        public string? LibrarySectionID { get; set; }
        [XmlAttribute(AttributeName = "librarySectionTitle")]
        public string? LibrarySectionTitle { get; set; }
        [XmlAttribute(AttributeName = "librarySectionUUID")]
        public string? LibrarySectionUUID { get; set; }
        [XmlAttribute(AttributeName = "title1")]
        public string? Title1 { get; set; }
        [XmlAttribute(AttributeName = "title2")]
        public string? Title2 { get; set; }
        [XmlAttribute(AttributeName = "viewGroup")]
        public string? ViewGroup { get; set; }
        [XmlAttribute(AttributeName = "viewMode")]
        public string? ViewMode { get; set; }
        [XmlAttribute(AttributeName = "hasPremiumExtras")]
        public string? HasPremiumExtras { get; set; }
    }

    [XmlRoot(ElementName = "MediaContainer")]
    public class MediaContainer
    {
        [XmlElement(ElementName = "Directory")]
        public List<Directory> Directory { get; set; } = [];
        [XmlAttribute(AttributeName = "size")]
        public string? Size { get; set; }
        [XmlAttribute(AttributeName = "allowSync")]
        public string? AllowSync { get; set; }
        [XmlAttribute(AttributeName = "art")]
        public string? Art { get; set; }
        [XmlAttribute(AttributeName = "identifier")]
        public string? Identifier { get; set; }
        [XmlAttribute(AttributeName = "librarySectionID")]
        public string? LibrarySectionID { get; set; }
        [XmlAttribute(AttributeName = "librarySectionTitle")]
        public string? LibrarySectionTitle { get; set; }
        [XmlAttribute(AttributeName = "librarySectionUUID")]
        public string? LibrarySectionUUID { get; set; }
        [XmlAttribute(AttributeName = "mediaTagPrefix")]
        public string? MediaTagPrefix { get; set; }
        [XmlAttribute(AttributeName = "mediaTagVersion")]
        public string? MediaTagVersion { get; set; }
        [XmlAttribute(AttributeName = "thumb")]
        public string? Thumb { get; set; }
        [XmlAttribute(AttributeName = "title1")]
        public string? Title1 { get; set; }
        [XmlAttribute(AttributeName = "title2")]
        public string? Title2 { get; set; }
        [XmlAttribute(AttributeName = "viewGroup")]
        public string? ViewGroup { get; set; }
        [XmlAttribute(AttributeName = "viewMode")]
        public string? ViewMode { get; set; }
    }
}
