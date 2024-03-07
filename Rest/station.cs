using System.Text.Json.Serialization;

class Station {
    [JsonPropertyName("Name")]
    public string Name { get; set; }
    [JsonPropertyName("SiteId")]
    public string Id { get; set; }
}