﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using assessment.report.db;

namespace assessment.report.db.Migrations
{
    [DbContext(typeof(ReportDBContext))]
    [Migration("20220130152953_AddDosyaYoluToRaporTable")]
    partial class AddDosyaYoluToRaporTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("assessment.report.db.Entities.Rapor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Dosyayolu")
                        .HasColumnType("text");

                    b.Property<int>("RaporDurumId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TalepTarihi")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("RaporDurumId");

                    b.ToTable("Rapor");
                });

            modelBuilder.Entity("assessment.report.db.Entities.RaporDurum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Durum")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RaporDurum");
                });

            modelBuilder.Entity("assessment.report.db.Entities.Rapor", b =>
                {
                    b.HasOne("assessment.report.db.Entities.RaporDurum", "RaporDurum")
                        .WithMany()
                        .HasForeignKey("RaporDurumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RaporDurum");
                });
#pragma warning restore 612, 618
        }
    }
}
