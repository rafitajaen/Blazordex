using System.Text.Json.Serialization;

namespace Blazordex.Models;

public record Sprites
{
    [JsonPropertyName("front_default")]
    public string Default { get; init; }

    [JsonPropertyName("front_female")]
    public string Female { get; init; }

    [JsonPropertyName("front_shiny")]
    public string Shiny { get; init; }
}