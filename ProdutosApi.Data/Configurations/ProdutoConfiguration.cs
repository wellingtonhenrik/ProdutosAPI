using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTO");

            builder.HasKey(a => a.ProdutoId);

            builder.Property(p => p.ProdutoId).HasColumnName("PRODUTOID");

            builder.Property(p => p.Nome).HasColumnName("NOME").HasMaxLength(150).IsRequired();

            builder.Property(p => p.Descricao).HasColumnName("DESCRICAO").HasMaxLength(250).IsRequired();

            builder.Property(p => p.Preco).HasColumnName("PRECO").HasColumnType("decimal(18,2)").IsRequired();

            builder.Property(p => p.Quantidade).HasColumnName("QUANTIDADE").IsRequired();

            builder.Property(p => p.DataHoraCadastro).HasColumnName("DATAHORACADASTRO").IsRequired();

            builder.Property(p => p.DataHoraUltimaAlteracao).HasColumnName("DATAHORAULTIMAALTERACAO");
        }
    }
}
