using poke_api_back.Models;

namespace poke_api_back.Services
{
    public interface IPokeService
    {
        Task<PokeModel> GetPokemonByIdAsync(string id);
        Task<List<PokeModel>> GetPokemonsByTypeAsync(string type, int page);
        Task<List<PokeModel>> GetPokemonsByNameAsync(string name);
        Task<List<PokeModel>> GetPokemonsByAbilityAsync(string ability, int page);
    }
}
