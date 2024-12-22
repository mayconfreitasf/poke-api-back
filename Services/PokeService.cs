using Microsoft.AspNetCore.Mvc.RazorPages;
using poke_api_back.Models;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;

namespace poke_api_back.Services
{
    public class PokeService : IPokeService
    {
        private readonly HttpClient _httpClient;

        public PokeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private async Task<List<PokeModel>> LoadPoke(string response, int page, int limit,
            Func<JsonElement, int, int, IEnumerable<JsonElement>> paginationFunc, 
            Func<string, Task<PokeModel>> fetchPokemonData)
        {
            var pokeApiResponse = JsonSerializer.Deserialize<JsonElement>(response);
            var paginatedPokemons = paginationFunc(pokeApiResponse, page, limit);

            var tasks = paginatedPokemons.Select(poke =>
                fetchPokemonData(poke.GetProperty("pokemon").GetProperty("url").GetString())
            );

            var pokemons = await Task.WhenAll(tasks);

            return pokemons.ToList();
        }

        private IEnumerable<JsonElement> PaginatePokemons(JsonElement pokeApiResponse, int page, int limit)
        {
            return pokeApiResponse
                .GetProperty("pokemon")
                .EnumerateArray()
                .Skip((page - 1) * limit)  
                .Take(limit);
        }

        private async Task<PokeModel> FetchPokemonData(string pokemonUrl)
        {
            var pokemonData = await _httpClient.GetStringAsync(pokemonUrl);
            return JsonSerializer.Deserialize<PokeModel>(pokemonData);
        }

        public async Task<PokeModel> GetPokemonByIdAsync(string id)
        {
            var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
            var pokemon = JsonSerializer.Deserialize<PokeModel>(response);

            return pokemon;
        }

        public async Task<List<PokeModel>> GetPokemonsByTypeAsync(string type, int page)
        {
            var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/type/{type.ToLower()}");
            return await LoadPoke(response, page, 2, PaginatePokemons, FetchPokemonData);
        }
        public async Task<List<PokeModel>> GetPokemonsByNameAsync(string name)
        {
            var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{name.ToLower()}");
            var pokeData = JsonSerializer.Deserialize<PokeModel>(response);
            return new List<PokeModel> { pokeData };
        }

        public async Task<List<PokeModel>> GetPokemonsByAbilityAsync(string ability, int page)
        {
            var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/ability/{ability.ToLower()}");
            return await LoadPoke(response, page, 4, PaginatePokemons, FetchPokemonData);
        }

    }


}
