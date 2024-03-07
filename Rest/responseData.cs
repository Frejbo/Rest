using System.Text.Json.Serialization;

class ResponseData {
    [JsonPropertyName("ResponseData")]
    public List<Station> Stations { get; set; }
}