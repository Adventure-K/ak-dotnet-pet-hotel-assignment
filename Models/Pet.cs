using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public enum PetBreedType
    {
        Shepherd,
        Poodle,
        Beagle,
        Bulldog,
        Terrier,
        Boxer,
        Labrador,
        Retriever
    }
    public enum PetColorType
    {
        Black,
        White,
        Golden,
        Tricolor,
        Spotted
    }
    public class Pet
    {
        public int id { get; set; }
        public string name { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public string PetBreedType { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public string PetColorType { get; set; }

        public bool checkedIn { get; set; }
        [ForeignKey("ownedBy")]
        public int ownedBy { get; set; }

        // public Owner ownedBy {get;set;}

    }
}
