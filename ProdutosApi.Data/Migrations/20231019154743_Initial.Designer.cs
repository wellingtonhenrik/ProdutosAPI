﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProdutosApi.Data.Contexts;

#nullable disable

namespace ProdutosApi.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231019154743_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProdutosApi.Data.Entities.Produto", b =>
                {
                    b.Property<Guid?>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PRODUTOID");

                    b.Property<DateTime?>("DataHoraCadastro")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("DATAHORACADASTRO");

                    b.Property<DateTime?>("DataHoraUltimaAlteracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATAHORAULTIMAALTERACAO");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("DESCRICAO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NOME");

                    b.Property<decimal?>("Preco")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("PRECO");

                    b.Property<int?>("Quantidade")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("QUANTIDADE");

                    b.HasKey("ProdutoId");

                    b.ToTable("PRODUTO", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
