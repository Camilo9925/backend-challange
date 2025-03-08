using System.Text.Json.Serialization;

namespace Challenge.Domain.Entities;

public class InputTool(string title, string link, string description, List<string> tags)
{
    [JsonIgnore]
    [JsonPropertyName("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [JsonPropertyName("title")]
    public string Title { get; set; } = title;
    [JsonPropertyName("link")]
    public string Link { get; set; } = link;
    [JsonPropertyName("description")]
    public string Description { get; set; } = description;
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; } = tags;
}
