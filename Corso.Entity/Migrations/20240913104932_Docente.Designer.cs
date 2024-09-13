﻿// <auto-generated />
using Corso.Entity.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Corso.Entity.Migrations
{
    [DbContext(typeof(CorsoFormazioneContext))]
    [Migration("20240913104932_Docente")]
    partial class Docente
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Corso.Entity.DAL.Aula", b =>
                {
                    b.Property<int>("Idaula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idaula"));

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("NumeroPosti")
                        .HasColumnType("int");

                    b.HasKey("Idaula");

                    b.ToTable("Aula");
                });

            modelBuilder.Entity("Corso.Entity.DAL.Docente", b =>
                {
                    b.Property<int>("IDDocente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDDocente"));

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IDDocente");

                    b.ToTable("Docente");
                });
#pragma warning restore 612, 618
        }
    }
}
