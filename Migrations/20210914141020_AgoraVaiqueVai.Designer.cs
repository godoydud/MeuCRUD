﻿// <auto-generated />
using System;
using MeuCRUD.Models.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeuCRUD.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20210914141020_AgoraVaiqueVai")]
    partial class AgoraVaiqueVai
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MeuCRUD.Models.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ImagemId")
                        .HasColumnType("int");

                    b.Property<string>("NomeUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ImagemId")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("MeuCRUD.Models.Entidades.UsuarioImagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Imagem")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("UsuarioImagem");
                });

            modelBuilder.Entity("MeuCRUD.Models.Entidades.Usuario", b =>
                {
                    b.HasOne("MeuCRUD.Models.Entidades.UsuarioImagem", "Imagem")
                        .WithOne()
                        .HasForeignKey("MeuCRUD.Models.Entidades.Usuario", "ImagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}