using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using MongoDB.Bson.Serialization.IdGenerators;
using System.ComponentModel.DataAnnotations;


namespace _Nexus.Models
{
    [Collection("NX_USUARIO")]
    public class UsuarioModel
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("NomeUsuario")]
        [Required]
        public string NomeUsuario { get; set; }

        [BsonElement("CPF")]
        [Required]
        public string CPF { get; set; }

        [BsonElement("Email")]
        [Required]
        public string Email { get; set; }

        [BsonElement("Telefone")]
        [Required]
        public string Telefone { get; set; }
    }
}