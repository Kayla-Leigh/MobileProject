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

            [JsonProperty("animal")]
            public Animal Animal { get; set; }

            [JsonProperty("age")]
            public Age Age { get; set; }

            [JsonProperty("sex")]
            public Sex Sex { get; set; }

            [JsonProperty("name")]
            public Name Name { get; set; }

            [JsonProperty("size")]
            public Size Size { get; set; }

            [JsonProperty("description")]
            public Description Description { get; set; }

            [JsonProperty("lastUpdate")]
            public LastUpdate LastUpdate { get; set; }
        }

        public partial class LastUpdate
        {
            [JsonProperty("$t")]
            public string Update { get; set; }
        }

        public partial class Description
        {
            [JsonProperty("$t")]
            public string AnimalDescription { get; set; }
        }

        public partial class Size
        {
            [JsonProperty("$t")]
            public string AnimalSize { get; set; }
        }

        public partial class Name
        {
            [JsonProperty("$t")]
            public string AnimalName { get; set; }
        }

        public partial class Sex
        {
            [JsonProperty("$t")]
            public string AnimalSex { get; set; }
        }

        public partial class Age
        {
            [JsonProperty("$t")]
            public string AnimalAge { get; set; }
        }

        public partial class Animal
        {
            [JsonProperty("$t")]
            public string AnimalType { get; set; }
        }

        public partial class Contact
        {
            [JsonProperty("zip")]
            public Zip Zip { get; set; }

            [JsonProperty("city")]
            public City City { get; set; }

            [JsonProperty("state")]
            public State State { get; set; }

            [JsonProperty("address1")]
            public Address Address { get; set; }

            [JsonProperty("phone")]
            public Phone Phone { get; set; }
        }

        public partial class Phone
        {
            [JsonProperty("photos")]
            public string PhoneNumber { get; set; }
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

        public partial class State
        {
            [JsonProperty("$t")]
            public string StateLocation { get; set; }
        }

        public partial class Address
        {
            [JsonProperty("$t")]
            public string AddressLocation { get; set; }
        }

        public partial class City
        {
            [JsonProperty("$t")]
            public string CityLocation { get; set; }
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