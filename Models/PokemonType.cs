using System.Text.Json.Serialization;

namespace Blazordex.Models;

public record PokemonType
{
    [JsonPropertyName("slot")]
    public int Slot { get; init; }

    [JsonPropertyName("type")]
    public NamedModel Type { get; init; }
}