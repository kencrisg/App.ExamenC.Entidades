﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.ExamenC.API.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20240515165525_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.ExamenC.Entidades.Conferencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lugar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Conferencia");
                });

            modelBuilder.Entity("App.ExamenC.Entidades.Ponente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConferenciaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tema")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConferenciaId");

                    b.ToTable("Ponente");
                });

            modelBuilder.Entity("App.ExamenC.Entidades.Ponente", b =>
                {
                    b.HasOne("App.ExamenC.Entidades.Conferencia", "Conferencia")
                        .WithMany("Ponentes")
                        .HasForeignKey("ConferenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conferencia");
                });

            modelBuilder.Entity("App.ExamenC.Entidades.Conferencia", b =>
                {
                    b.Navigation("Ponentes");
                });
#pragma warning restore 612, 618
        }
    }
}
