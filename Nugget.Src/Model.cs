using System.Text.Json.Serialization;

namespace Models;

public class Context
{
    [JsonPropertyName("@vocab")]
    public string? Vocab { get; set; }

    [JsonPropertyName("@base")]
    public string? Base { get; set; }
}

public class Datum
{
    [JsonPropertyName("@id")]
    public string? @Id { get; set; }

    [JsonPropertyName("@type")]
    public string? Type { get; set; }

    [JsonPropertyName("registration")]
    public string? Registration { get; set; }

    [JsonPropertyName("id")]
    public required string PackageId { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("iconUrl")]
    public string? IconUrl { get; set; }

    [JsonPropertyName("licenseUrl")]
    public string? LicenseUrl { get; set; }

    [JsonPropertyName("projectUrl")]
    public string? ProjectUrl { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("authors")]
    public List<string>? Authors { get; set; }

    [JsonPropertyName("owners")]
    public List<string>? Owners { get; set; }

    [JsonPropertyName("totalDownloads")]
    public int? TotalDownloads { get; set; }

    [JsonPropertyName("verified")]
    public required bool Verified { get; set; }

    [JsonPropertyName("packageTypes")]
    public List<PackageType>? PackageTypes { get; set; }

    [JsonPropertyName("versions")]
    public List<Version>? Versions { get; set; }

    [JsonPropertyName("vulnerabilities")]
    public List<object>? Vulnerabilities { get; set; }
}

public class PackageType
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

public class Root
{
    [JsonPropertyName("@context")]
    public Context? Context { get; set; }

    [JsonPropertyName("totalHits")]
    public int? TotalHits { get; set; }

    [JsonPropertyName("data")]
    public List<Datum>? Data { get; set; }
}

public class Version
{
    [JsonPropertyName("version")]
    public string? PackageVersion { get; set; }

    [JsonPropertyName("downloads")]
    public int? Downloads { get; set; }

    [JsonPropertyName("@id")]
    public string? Id { get; set; }
}
