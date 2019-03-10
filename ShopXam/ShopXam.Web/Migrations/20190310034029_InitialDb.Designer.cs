﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopXam.Web.Data;

namespace ShopXam.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190310034029_InitialDb")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopXam.Web.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Disponible");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Nombre");

                    b.Property<decimal>("Precio");

                    b.Property<double>("Stock");

                    b.Property<DateTime>("UltimaCompra");

                    b.HasKey("Id");

                    b.ToTable("Prooducto");
                });
#pragma warning restore 612, 618
        }
    }
}