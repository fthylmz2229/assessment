﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using assessment.contact.db;

namespace assessment.contact.db.Migrations
{
    [DbContext(typeof(ContactDBContext))]
    [Migration("20220129215907_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("assessment.contact.db.Entities.IletisimBilgiTipi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Ad")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("IletisimBilgiTipi");
                });

            modelBuilder.Entity("assessment.contact.db.Entities.Kisi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Ad")
                        .HasColumnType("text");

                    b.Property<string>("Firma")
                        .HasColumnType("text");

                    b.Property<string>("Soyad")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Kisi");
                });

            modelBuilder.Entity("assessment.contact.db.Entities.KisiIletisimBilgi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BilgiIcerigi")
                        .HasColumnType("text");

                    b.Property<int>("IletisimBilgiTipiId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IletisimBilgiTipiId");

                    b.ToTable("KisiIletisimBilgi");
                });

            modelBuilder.Entity("assessment.contact.db.Entities.KisiIletisimBilgi", b =>
                {
                    b.HasOne("assessment.contact.db.Entities.IletisimBilgiTipi", "IletisimBilgiTipi")
                        .WithMany()
                        .HasForeignKey("IletisimBilgiTipiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IletisimBilgiTipi");
                });
#pragma warning restore 612, 618
        }
    }
}
