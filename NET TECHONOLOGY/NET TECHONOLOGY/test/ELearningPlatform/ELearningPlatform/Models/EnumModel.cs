using System.Text.Json.Serialization;

namespace ELearningPlatform.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumModel
    {
        articles,
        text,
        doucment 
    }
}
