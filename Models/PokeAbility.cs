using System.Text.Json.Serialization;

namespace poke_api_back.Models
{
    public class PokeAbility
    {
        [JsonPropertyName("ability")]
        public PokeAbilityItem AbilityItem { get; set; }
    }

    public class PokeAbilityItem
    {
        [JsonPropertyName("name")]
        public string AbilityName { get; set; }
    }
}
