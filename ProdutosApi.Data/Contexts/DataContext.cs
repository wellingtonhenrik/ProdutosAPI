using Microsoft.EntityFrameworkCore;
using ProdutosApi.Data.Configurations;
using ProdutosApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Data.Contexts
{
    /// <summary>
    /// Classe para acesso ao banco de dado atraves do Entity
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Método para realizar a conexão com o banco de dados do projeto
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase(databaseName: "BDProdutosApi");

            optionsBuilder.UseSqlServer("Data Source=WELLINGTON\\SQLEXPRESS;Initial Catalog=ProdutosAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }


        /// <summary>
        /// Método para adicionar as classes de mapeamento ORM do projeto
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        }


        /// <summary>
        /// Propriedade para fazer a persistencia do produto (CRUD)
        /// </summary>
        public DbSet<Produto> Produto { get; set; }

    }
}
