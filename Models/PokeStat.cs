using System.Text.Json.Serialization;

namespace poke_api_back.Models
{
    public class PokeStat
    {
        [JsonPropertyName("stat")]
        public PokeStatItem StatItem { get; set; }

        [JsonPropertyName("base_stat")]
        public int BaseStat { get; set; }
    }

    public class PokeStatItem
    {
        [JsonPropertyName("name")]
        public string StatName { get; set; }
    }
}

