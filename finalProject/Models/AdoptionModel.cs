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
            [JsonProperty("petfinder")]
            public PetFinder PetFinder { get; set; }

        }
        public partial class PetFinder
        {
            [JsonProperty("pets")]
            public Pets Pets { get; set; }
        }

        public partial class Pets
        {
            [JsonProperty("pet")]
            public Pet[] Pet { get; set; }
        }

        public partial class Pet
        {
            [JsonProperty("contact")]
            public Contact Contact { get; set; }

            //[JsonProperty("media")]
            //public Media Media { get; set; }

            /*[JsonProperty("breeds")]
            public Breeds[] Breeds { get; set; }*/

            [JsonProperty("animal")]
            public Animal Animal { get; set; }
        }

        public partial class Animal
        {
            [JsonProperty("$t")]
            public string AnimalType { get; set; }
        }

        /*public partial class Breeds
        {
            [JsonProperty("breed")]
            public Breed Breed { get; set; }
        }*/

        /*public partial class Breed
        {
            [JsonProperty("$t")]
            public string BreedType { get; set; }
        }*/

        public partial class Contact
        {
            [JsonProperty("zip")]
            public Zip Zip { get; set; }
        }

        public partial class Media
        {
            [JsonProperty("photos")]
            public Photos Photos { get; set; }
        }

        public partial class Photos
        {
            [JsonProperty("photo")]
            public Photo Photo { get; set; }
        }

        public partial class Photo
        {
            [JsonProperty("$t")]
            public string Photograph { get; set; }
        }

        public partial class Zip
        {
            [JsonProperty("$t")]
            public double ZipCode { get; set; }
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