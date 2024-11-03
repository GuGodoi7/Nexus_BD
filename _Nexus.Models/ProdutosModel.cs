using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace _Nexus.Models
{
    [Collection("NX_PRODUTOS")]
    public class ProdutosModel
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdProduto { get; set; }

        [BsonElement("NomeProduto")]
        [Required]
        public string NomeProduto { get; set; }

        [BsonElement("TipoProduto")]
        [Required]
        public string TipoProduto { get; set; }

        [BsonElement("Marca")]
        [Required]
        public string Marca { get; set; }

        [BsonElement("Modelo")]
        [Required]
        public string Modelo { get; set; }

        [BsonElement("Quantidade")]
        [Required]
        public int Quantidade { get; set; }

        [BsonElement("ValorProduto")]
        [Required]
        public Decimal ValorProduto { get; set; }

        [BsonElement("DescricaoProduto")]
        [Required]
        public string DescricaoProduto { get; set; }

        [BsonElement("status")]
        [Required]
        public string status { get; set; }

        [BsonElement("estoque ")]
        [Required]
        public string estoque { get; set; }

        [BsonElement("codigoProduto")]
        [Required]
        public string codigoProduto { get; set; }
    }
}