﻿// <auto-generated />
using System;
using AT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AT.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AT.Models.Jogador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.Property<DateTime>("dataCriacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("Data");

                    b.HasKey("Id");

                    b.ToTable("Jogador");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Vegetti",
                            dataCriacao = new DateTime(2023, 12, 14, 18, 14, 18, 313, DateTimeKind.Local).AddTicks(6351)
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Ribamar",
                            dataCriacao = new DateTime(2023, 12, 14, 18, 14, 18, 313, DateTimeKind.Local).AddTicks(6352)
                        });
                });

            modelBuilder.Entity("AT.Models.Time", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.Property<DateTime>("dataCriacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("Data");

                    b.HasKey("Id");

                    b.ToTable("Time");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Vasco",
                            dataCriacao = new DateTime(2023, 12, 14, 18, 14, 18, 313, DateTimeKind.Local).AddTicks(6490)
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Atlético MG",
                            dataCriacao = new DateTime(2023, 12, 14, 18, 14, 18, 313, DateTimeKind.Local).AddTicks(6491)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
