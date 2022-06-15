using System.Text.Json.Serialization;

namespace Blazordex.Models;

public record NamedModel
{
    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("url")]
    public string Url { get; init; }
}