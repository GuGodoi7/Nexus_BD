using _Nexus.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace _Nexus.DataBase
{
    public class Context : DbContext
    {
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<ProdutosModel> Produto { get; set; }
        public DbSet<PedidosModel> Pedido { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}