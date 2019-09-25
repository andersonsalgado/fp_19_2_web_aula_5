﻿// <auto-generated />
using System;
using Fiap.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fiap.Core.Migrations
{
    [DbContext(typeof(TurismoContext))]
    [Migration("20190918224718_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fiap.Models.Destino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Distancia");

                    b.Property<string>("Nome");

                    b.Property<string>("Pais");

                    b.Property<int?>("TemporadaId");

                    b.HasKey("Id");

                    b.HasIndex("TemporadaId");

                    b.ToTable("Destinos");
                });

            modelBuilder.Entity("Fiap.Models.Temporada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Temporadas");
                });

            modelBuilder.Entity("Fiap.Models.Destino", b =>
                {
                    b.HasOne("Fiap.Models.Temporada", "Temporada")
                        .WithMany()
                        .HasForeignKey("TemporadaId");
                });
#pragma warning restore 612, 618
        }
    }
}
