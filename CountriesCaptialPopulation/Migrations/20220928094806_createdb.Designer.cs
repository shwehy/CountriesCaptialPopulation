﻿// <auto-generated />
using CountriesCaptialPopulation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CountriesCaptialPopulation.Migrations
{
    [DbContext(typeof(CountryDbContext))]
    [Migration("20220928094806_createdb")]
    partial class createdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CountriesCaptialPopulation.Model.Country", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("countries");
                });

            modelBuilder.Entity("CountriesCaptialPopulation.Model.PopulationList", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("countryCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("value")
                        .HasColumnType("int");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("countryCode");

                    b.ToTable("PopulationList");
                });

            modelBuilder.Entity("CountriesCaptialPopulation.Model.PopulationList", b =>
                {
                    b.HasOne("CountriesCaptialPopulation.Model.Country", "country")
                        .WithMany("Populations")
                        .HasForeignKey("countryCode");

                    b.Navigation("country");
                });

            modelBuilder.Entity("CountriesCaptialPopulation.Model.Country", b =>
                {
                    b.Navigation("Populations");
                });
#pragma warning restore 612, 618
        }
    }
}
