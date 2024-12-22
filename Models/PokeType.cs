using System.Text.Json.Serialization;

namespace poke_api_back.Models
{
    public class PokeType
    {
        [JsonPropertyName("type")]
        public PokeTypeItem TypeItem { get; set; }
    }

    public class PokeTypeItem
    {
        [JsonPropertyName("name")]
        public string TypeName { get; set; }
    }
}
