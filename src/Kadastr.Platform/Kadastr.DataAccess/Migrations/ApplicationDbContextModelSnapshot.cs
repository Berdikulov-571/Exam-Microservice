﻿// <auto-generated />
using System;
using Kadastr.DataAccess.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kadastr.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kadastr.Domain.Entities.LandUses.LandUse", b =>
                {
                    b.Property<int>("LandUseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LandUseID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LandUseType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("LandUseID");

                    b.ToTable("LandUses");
                });

            modelBuilder.Entity("Kadastr.Domain.Entities.LegalDescriptions.LegalDescription", b =>
                {
                    b.Property<int>("LegalDescriptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LegalDescriptionID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescriptionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParcelID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("LegalDescriptionID");

                    b.HasIndex("ParcelID");

                    b.ToTable("LegalDescriptions");
                });

            modelBuilder.Entity("Kadastr.Domain.Entities.Owners.Owner", b =>
                {
                    b.Property<int>("OwnerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OwnerID"));

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("OwnerID");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("Kadastr.Domain.Entities.Parcels.Parcel", b =>
                {
                    b.Property<int>("ParcelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParcelID"));

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("OwnerID")
                        .HasColumnType("int");

                    b.Property<string>("ParcelNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ParcelID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Parcels");
                });

            modelBuilder.Entity("Kadastr.Domain.Entities.PercalLandUses.PercalLandUse", b =>
                {
                    b.Property<int>("ParcelLandUseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParcelLandUseID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LandUseID")
                        .HasColumnType("int");

                    b.Property<int>("ParcelID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ParcelLandUseID");

                    b.HasIndex("LandUseID");

                    b.HasIndex("ParcelID");

                    b.ToTable("PercalLandUses");
                });

            modelBuilder.Entity("Kadastr.Domain.Entities.Transactions.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionID"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ParcelID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionID");

                    b.HasIndex("ParcelID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Kadastr.Domain.Entities.LegalDescriptions.LegalDescription", b =>
                {
                    b.HasOne("Kadastr.Domain.Entities.Parcels.Parcel", "Parcel")
                        .WithMany()
                        .HasForeignKey("ParcelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parcel");
                });

            modelBuilder.Entity("Kadastr.Domain.Entities.Parcels.Parcel", b =>
                {
                    b.HasOne("Kadastr.Domain.Entities.Owners.Owner", "Owner")
                        .WithMany("Parcels")
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Kadastr.Domain.Entities.PercalLandUses.PercalLandUse", b =>
                {
                    b.HasOne("Kadastr.Domain.Entities.LandUses.LandUse", "LandUse")
                        .WithMany()
                        .HasForeignKey("LandUseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kadastr.Domain.Entities.Parcels.Parcel", "Parcel")
                        .WithMany()
                        .HasForeignKey("ParcelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LandUse");

                    b.Navigation("Parcel");
                });

            modelBuilder.Entity("Kadastr.Domain.Entities.Transactions.Transaction", b =>
                {
                    b.HasOne("Kadastr.Domain.Entities.Parcels.Parcel", "Parcel")
                        .WithMany()
                        .HasForeignKey("ParcelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parcel");
                });

            modelBuilder.Entity("Kadastr.Domain.Entities.Owners.Owner", b =>
                {
                    b.Navigation("Parcels");
                });
#pragma warning restore 612, 618
        }
    }
}
