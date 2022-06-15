using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Blazordex.Models;

public record GetPokemonListResponse
{
    [JsonPropertyName("results")] 
    public ICollection<NamedModel> Pokemons { get; init; } = new Collection<NamedModel>();

    [JsonPropertyName("next")] 
    public string? NextPage { get; init; }
}