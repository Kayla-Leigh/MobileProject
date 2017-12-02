using System;
using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;
namespace finalProject.Models
{
    public static class AdoptionModel
    {
        public partial class Pets
        {
            [JsonProperty("pet")]
            public Pet Pet { get; set; }
  
        }

        public partial class Pet
        {
            [JsonProperty("contact")]
            public Contact Contact { get; set; }
        }

        public partial class Contact
        {
            [JsonProperty("zip")]
            public Zip Zip { get; set;  }
        }

        public partial class Zip
        {
            [JsonProperty("$t")]
            public double zip { get; set; }
        }

        public partial class AdoptionItem
        {
            public static AdoptionItem FromJson(string json) => JsonConvert.DeserializeObject<AdoptionItem>(json, Converter.Settings);
        }

        public static string ToJson(this AdoptionItem self) => JsonConvert.SerializeObject(self, Converter.Settings);

        public class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
            };
        }
    }
}
