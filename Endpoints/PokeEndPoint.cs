using Microsoft.AspNetCore.Mvc;
using poke_api_back.Models;
using poke_api_back.Services;
using System.Collections.Generic;

namespace poke_api_back.Endpoints
{
    public static class PokeEndPoint
    {
        public static void MapPokeEndpoints(this IEndpointRouteBuilder routes)
        {

            routes.MapGet("/pokemons/{id}", async (string id, IPokeService pokeService) =>
            {
                var pokemon = await pokeService.GetPokemonByIdAsync(id);
                return pokemon != null ? Results.Ok(pokemon) : Results.NotFound();
            });

            routes.MapGet("/pokemons/ability/{ability}/page/{page}", async (string ability, int page, IPokeService pokeService) =>
            {
                var pokemon = await pokeService.GetPokemonsByAbilityAsync(ability, page);
                return pokemon != null ? Results.Ok(pokemon) : Results.NotFound();
            });

            routes.MapGet("/pokemons/type/{type}/page/{page}", async (string type, int page, IPokeService pokeService) =>
            {
                var pokemon = await pokeService.GetPokemonsByTypeAsync(type, page);
                return pokemon != null ? Results.Ok(pokemon) : Results.NotFound();
            });

            routes.MapGet("/pokemons/name/{name}", async (string name, IPokeService pokeService) =>
            {
                var pokemon = await pokeService.GetPokemonsByNameAsync(name);
                return pokemon != null ? Results.Ok(pokemon) : Results.NotFound();
            });

        }
    }
}
