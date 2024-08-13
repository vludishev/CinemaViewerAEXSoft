using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CV.App.APIs.Constants
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Categories
    {
        Business,
        Entertainment,
        Health,
        Science,
        Sports,
        Technology
    }
}
