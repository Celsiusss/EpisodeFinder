using System.Xml.Serialization;

namespace EpisodeFinder.Models.Plex;

public class Metadata
{
        [XmlRoot(ElementName = "Video")]
    public class Video
    {
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
        [XmlAttribute(AttributeName = "librarySectionTitle")]
        public string? LibrarySectionTitle { get; set; }
        [XmlAttribute(AttributeName = "librarySectionID")]
        public string? LibrarySectionID { get; set; }
        [XmlAttribute(AttributeName = "librarySectionKey")]
        public string? LibrarySectionKey { get; set; }
        [XmlAttribute(AttributeName = "contentRating")]
        public string? ContentRating { get; set; }
        [XmlAttribute(AttributeName = "summary")]
        public string? Summary { get; set; }
        [XmlAttribute(AttributeName = "rating")]
        public string? Rating { get; set; }
        [XmlAttribute(AttributeName = "audienceRating")]
        public string? AudienceRating { get; set; }
        [XmlAttribute(AttributeName = "viewCount")]
        public string? ViewCount { get; set; }
        [XmlAttribute(AttributeName = "lastViewedAt")]
        public string? LastViewedAt { get; set; }
        [XmlAttribute(AttributeName = "year")]
        public string? Year { get; set; }
        [XmlAttribute(AttributeName = "tagline")]
        public string? Tagline { get; set; }
        [XmlAttribute(AttributeName = "thumb")]
        public string? Thumb { get; set; }
        [XmlAttribute(AttributeName = "art")]
        public string? Art { get; set; }
        [XmlAttribute(AttributeName = "duration")]
        public string? Duration { get; set; }
        [XmlAttribute(AttributeName = "originallyAvailableAt")]
        public string? OriginallyAvailableAt { get; set; }
        [XmlAttribute(AttributeName = "addedAt")]
        public string? AddedAt { get; set; }
        [XmlAttribute(AttributeName = "updatedAt")]
        public string? UpdatedAt { get; set; }
        [XmlAttribute(AttributeName = "audienceRatingImage")]
        public string? AudienceRatingImage { get; set; }
        [XmlAttribute(AttributeName = "chapterSource")]
        public string? ChapterSource { get; set; }
        [XmlAttribute(AttributeName = "hasPremiumExtras")]
        public string? HasPremiumExtras { get; set; }
        [XmlAttribute(AttributeName = "hasPremiumPrimaryExtra")]
        public string? HasPremiumPrimaryExtra { get; set; }
        [XmlAttribute(AttributeName = "ratingImage")]
        public string? RatingImage { get; set; }
        [XmlElement(ElementName = "Media")]
        public Media? Media { get; set; }
        [XmlElement(ElementName = "Genre")]
        public List<Genre> GenreList { get; set; } = [];
        [XmlElement(ElementName = "Country")]
        public List<Country> CountryList { get; set; } = [];
        [XmlElement(ElementName = "Guid")]
        public List<Guid> ExternalGuids { get; set; } = [];
        [XmlElement(ElementName = "Rating")]
        public List<Rating> RatingList { get; set; } = [];
        [XmlElement(ElementName = "Director")]
        public List<Director> DirectorList { get; set; } = [];
        [XmlElement(ElementName = "Writer")]
        public List<Writer> WriterList { get; set; } = [];
        [XmlElement(ElementName = "Role")]
        public List<Role> RoleList { get; set; } = [];
        [XmlElement(ElementName = "Producer")]
        public List<Producer> ProducerList { get; set; } = [];
        [XmlAttribute(AttributeName = "parentRatingKey")]
        public string ParentRatingKey { get; set; }
        [XmlAttribute(AttributeName = "grandparentRatingKey")]
        public string GrandparentRatingKey { get; set; }
        [XmlAttribute(AttributeName = "parentGuid")]
        public string ParentGuid { get; set; }
        [XmlAttribute(AttributeName = "grandparentGuid")]
        public string GrandparentGuid { get; set; }
        [XmlAttribute(AttributeName = "grandparentSlug")]
        public string GrandparentSlug { get; set; }
        [XmlAttribute(AttributeName = "titleSort")]
        public string TitleSort { get; set; }
        [XmlAttribute(AttributeName = "grandparentKey")]
        public string GrandparentKey { get; set; }
        [XmlAttribute(AttributeName = "parentKey")]
        public string ParentKey { get; set; }
        [XmlAttribute(AttributeName = "grandparentTitle")]
        public string GrandparentTitle { get; set; }
        [XmlAttribute(AttributeName = "parentTitle")]
        public string ParentTitle { get; set; }
        [XmlAttribute(AttributeName = "index")]
        public int Index { get; set; }
        [XmlAttribute(AttributeName = "parentIndex")]
        public int ParentIndex { get; set; }
    }

    [XmlRoot(ElementName = "Media")]
    public class Media
    {
        [XmlElement(ElementName = "Part")]
        public Part? Part { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string? Id { get; set; }
        [XmlAttribute(AttributeName = "duration")]
        public string? Duration { get; set; }
        [XmlAttribute(AttributeName = "bitrate")]
        public string? Bitrate { get; set; }
        [XmlAttribute(AttributeName = "width")]
        public string? Width { get; set; }
        [XmlAttribute(AttributeName = "height")]
        public string? Height { get; set; }
        [XmlAttribute(AttributeName = "aspectRatio")]
        public string? AspectRatio { get; set; }
        [XmlAttribute(AttributeName = "audioChannels")]
        public string? AudioChannels { get; set; }
        [XmlAttribute(AttributeName = "audioCodec")]
        public string? AudioCodec { get; set; }
        [XmlAttribute(AttributeName = "videoCodec")]
        public string? VideoCodec { get; set; }
        [XmlAttribute(AttributeName = "videoResolution")]
        public string? VideoResolution { get; set; }
        [XmlAttribute(AttributeName = "container")]
        public string? Container { get; set; }
        [XmlAttribute(AttributeName = "videoFrameRate")]
        public string? VideoFrameRate { get; set; }
        [XmlAttribute(AttributeName = "videoProfile")]
        public string? VideoProfile { get; set; }
    }

    [XmlRoot(ElementName = "Part")]
    public class Part
    {
        [XmlAttribute(AttributeName = "id")]
        public string? Id { get; set; }
        [XmlAttribute(AttributeName = "key")]
        public string? Key { get; set; }
        [XmlAttribute(AttributeName = "duration")]
        public string? Duration { get; set; }
        [XmlAttribute(AttributeName = "file")]
        public string? File { get; set; }
        [XmlAttribute(AttributeName = "size")]
        public string? Size { get; set; }
        [XmlAttribute(AttributeName = "container")]
        public string? Container { get; set; }
        [XmlAttribute(AttributeName = "videoProfile")]
        public string? VideoProfile { get; set; }
    }

    [XmlRoot(ElementName = "Genre")]
    public class Genre
    {
        [XmlAttribute(AttributeName = "id")]
        public string? Id { get; set; }
        [XmlAttribute(AttributeName = "filter")]
        public string? Filter { get; set; }
        [XmlAttribute(AttributeName = "tag")]
        public string? Tag { get; set; }
    }

    [XmlRoot(ElementName = "Country")]
    public class Country
    {
        [XmlAttribute(AttributeName = "id")]
        public string? Id { get; set; }
        [XmlAttribute(AttributeName = "filter")]
        public string? Filter { get; set; }
        [XmlAttribute(AttributeName = "tag")]
        public string? Tag { get; set; }
    }

    [XmlRoot(ElementName = "Guid")]
    public class Guid
    {
        [XmlAttribute(AttributeName = "id")]
        public string? Id { get; set; }
    }

    [XmlRoot(ElementName = "Rating")]
    public class Rating
    {
        [XmlAttribute(AttributeName = "image")]
        public string? Image { get; set; }
        [XmlAttribute(AttributeName = "scheme")]
        public string? Scheme { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string? Value { get; set; }
    }

    [XmlRoot(ElementName = "Director")]
    public class Director
    {
        [XmlAttribute(AttributeName = "id")]
        public string? Id { get; set; }
    }

    [XmlRoot(ElementName = "Writer")]
    public class Writer
    {
        [XmlAttribute(AttributeName = "id")]
        public string? Id { get; set; }
    }

    [XmlRoot(ElementName = "Role")]
    public class Role
    {
        [XmlAttribute(AttributeName = "id")]
        public string? Id { get; set; }
        [XmlAttribute(AttributeName = "tag")]
        public string? Tag { get; set; }
    }

    [XmlRoot(ElementName = "Producer")]
    public class Producer
    {
        [XmlAttribute(AttributeName = "id")]
        public string? Id { get; set; }
    }
    
    [XmlRoot(ElementName = "Location")]
    public class Location
    {
        [XmlAttribute(AttributeName = "path")]
        public string? Path { get; set; }
    }
    
    [XmlRoot(ElementName = "Directory")]
    public class Directory
    {
        [XmlElement(ElementName = "Genre")]
        public List<Genre> Genres { get; set; } = [];
        [XmlElement(ElementName = "Guid")]
        public List<Guid> Guids { get; set; } = [];
        [XmlElement(ElementName = "Rating")]
        public List<Rating> Ratings { get; set; } = [];
        [XmlElement(ElementName = "Role")]
        public List<Role> Roles { get; set; } = [];
        [XmlElement(ElementName = "Location")]
        public List<Location> Locations { get; set; } = [];
        [XmlAttribute(AttributeName = "ratingKey")]
        public string? RatingKey { get; set; }
        [XmlAttribute(AttributeName = "key")]
        public string? Key { get; set; }
        [XmlAttribute(AttributeName = "guid")]
        public string? GuidAttribute { get; set; }
        [XmlAttribute(AttributeName = "slug")]
        public string? Slug { get; set; }
        [XmlAttribute(AttributeName = "studio")]
        public string? Studio { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string? Type { get; set; }
        [XmlAttribute(AttributeName = "title")]
        public string? Title { get; set; }
        [XmlAttribute(AttributeName = "librarySectionTitle")]
        public string? LibrarySectionTitle { get; set; }
        [XmlAttribute(AttributeName = "librarySectionID")]
        public string? LibrarySectionID { get; set; }
        [XmlAttribute(AttributeName = "librarySectionKey")]
        public string? LibrarySectionKey { get; set; }
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
        [XmlAttribute(AttributeName = "hasPremiumPrimaryExtra")]
        public string? HasPremiumPrimaryExtra { get; set; }
        [XmlAttribute(AttributeName = "primaryExtraKey")]
        public string? PrimaryExtraKey { get; set; }
    }

    [XmlRoot(ElementName = "MediaContainer")]
    public class MediaContainer
    {
        [XmlElement(ElementName = "Directory")]
        public List<Directory> Directories { get; set; } = [];
        [XmlElement(ElementName = "Video")]
        public List<Video> Videos { get; set; }
        [XmlAttribute(AttributeName = "size")]
        public string? Size { get; set; }
        [XmlAttribute(AttributeName = "allowSync")]
        public string? AllowSync { get; set; }
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
    }
}