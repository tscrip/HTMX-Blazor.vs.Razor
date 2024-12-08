using System.Text.Json.Serialization;

namespace HTMX_Blazor.vs.Razor.Models;

public class DogsResult
{
    [JsonPropertyName("message")]
    public string[] Message { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }
}