using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.IdGenerators;

namespace _Nexus.Models
{
    [Collection("NX_PEDIDOS")]
    public class PedidosModel
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdPedido { get; set; }

        [BsonElement("CodigoPedido")]
        [Required]
        public string CodigoPedido { get; set; }

        [BsonElement("Quantidade")]
        [Required]
        public int Quantidade { get; set; }

        [BsonElement("ValorPedido")]
        [Required]
        public decimal ValorPedido { get; set; }
    }
}
