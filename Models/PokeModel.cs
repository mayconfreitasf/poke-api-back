using System.Text.Json.Serialization;

namespace poke_api_back.Models
{
    public class PokeModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        public string Url { get; set; }

        [JsonPropertyName("types")]
        public List<PokeType> Types { get; set; }

        [JsonPropertyName("abilities")]
        public List<PokeAbility> Abilities { get; set; }

        [JsonPropertyName("stats")]
        public List<PokeStat> Stats { get; set; }
    }
}
