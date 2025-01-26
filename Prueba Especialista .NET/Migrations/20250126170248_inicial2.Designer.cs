﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prueba_Especialista_.NET.DbContexts;

#nullable disable

namespace Prueba_Especialista_.NET.Migrations
{
    [DbContext(typeof(VisitsDbContext))]
    [Migration("20250126170248_inicial2")]
    partial class inicial2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Prueba_Especialista_.NET.Models.Client", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Prueba_Especialista_.NET.Models.Commercial", b =>
                {
                    b.Property<Guid>("CommercialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommercialId");

                    b.ToTable("Commercials");
                });

            modelBuilder.Entity("Prueba_Especialista_.NET.Models.Visit", b =>
                {
                    b.Property<Guid>("VisitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CommercialId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateVisit")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VisitId");

                    b.HasIndex("ClientId");

                    b.HasIndex("CommercialId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("Prueba_Especialista_.NET.Models.Visit", b =>
                {
                    b.HasOne("Prueba_Especialista_.NET.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prueba_Especialista_.NET.Models.Commercial", "Commercial")
                        .WithMany()
                        .HasForeignKey("CommercialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Commercial");
                });
#pragma warning restore 612, 618
        }
    }
}
