using System.Net.Http.Json;
using Blazordex.Models;

namespace Blazordex.Clients;

public class PokeClient
{
    private readonly HttpClient _client;

    public PokeClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<GetPokemonListResponse> GetPokemons(int offset)
    {
        return await _client.GetFromJsonAsync<GetPokemonListResponse>($"pokemon?offset={offset}");
    }

    public async Task<Pokemon> GetPokemon(string url)
    {
        return await _client.GetFromJsonAsync<Pokemon>(url);
    }

    public async Task<Pokemon> GetPokemonByNameOrId(string identifier)
    {
        try
        {
            return await _client.GetFromJsonAsync<Pokemon>($"pokemon/{identifier.ToLower()}");
        }
        catch
        {
            // If there's an error we just want a null object
            return null;
        }
    }
}