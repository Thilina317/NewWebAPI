using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace NewWebAPI.Models
{
    public abstract class Question
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
