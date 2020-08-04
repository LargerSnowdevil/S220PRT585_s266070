﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieManager.Data;

namespace MovieManager.Migrations
{
    [DbContext(typeof(MovieDBContext))]
    partial class MovieDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieManager.Data.Movie", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("catagoryID")
                        .HasColumnType("int");

                    b.Property<string>("contactAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("directorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("movieLanguage")
                        .HasColumnType("int");

                    b.Property<string>("movieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("releaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MovieManager.Models.Catagory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Catagorys");
                });
#pragma warning restore 612, 618
        }
    }
}
