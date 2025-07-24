using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
//Representa lo que se guardará en la colección de mongodb
namespace CatGiphyApi.Models
{
    public class SearchRecord
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("date")]
        public DateTime Date { get; set; }

        [BsonElement("fact")]
        public string Fact { get; set; } = string.Empty;

        [BsonElement("queryWords")]
        public string QueryWords { get; set; } = string.Empty;

        [BsonElement("gifUrl")]
        public string GifUrl { get; set; } = string.Empty;
    }
}
