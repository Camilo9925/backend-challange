using System.Text.Json.Serialization;

namespace Challenge.Domain.Entities;

public class OutputTool
{
    [JsonPropertyName("id")]    
    public int Id { get; set; }
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    [JsonPropertyName("link")]
    public string? Link { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }
}

  