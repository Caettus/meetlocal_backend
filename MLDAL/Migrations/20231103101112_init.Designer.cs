﻿// <auto-generated />
using MLDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MLDAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231103101112_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MLDAL.Models.gathering", b =>
                {
                    b.Property<int>("GatheringId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GatheringId"));

                    b.Property<string>("GatheringCategory")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GatheringDateTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GatheringDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GatheringName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GatheringOrganiser")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("GatheringId");

                    b.ToTable("Gatherings");
                });
#pragma warning restore 612, 618
        }
    }
}
