using System;
using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;
namespace finalProject.Models
{
    public static class AdoptionModel
    {
        public partial class AdoptionItem
        {

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
