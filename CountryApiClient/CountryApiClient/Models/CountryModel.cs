using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace CountryApiClient.Models
{
    public class CountryModel
    {
        [JsonPropertyName("name")]
        public NameData Name { get; set; }
        [JsonPropertyName("capital")]
        public List<string> Capital { get; set; }
        [JsonPropertyName("continents")]
        public List<string> Continents { get; set; }
        [JsonPropertyName("languages")]
        public Dictionary<string, string> Languages { get; set; }
        [JsonPropertyName("population")]
        public long Population { get; set; }
    }

    public class NameData
    {
        [JsonPropertyName("common")]
        public string Common { get; set; }
        [JsonPropertyName("official")]
        public string Official { get; set; }

        [JsonPropertyName("nativeName")]
        public Dictionary<string, NativeNameInfo> NativeName { get; set; }
    }

    public class NativeNameInfo
    {
        [JsonPropertyName("official")]
        public string Official { get; set; }

        [JsonPropertyName("common")]
        public string Common { get; set; }
    }
}


