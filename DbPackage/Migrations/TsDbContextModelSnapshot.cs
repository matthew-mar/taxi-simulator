﻿// <auto-generated />
using System;
using DbPackage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbPackage.Migrations
{
    [DbContext(typeof(TsDbContext))]
    partial class TsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("DbPackage.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("IconPath")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("PlayerSigned")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("DbPackage.Models.Object", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float?>("Cost")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("Sold")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Objects");
                });

            modelBuilder.Entity("DbPackage.Models.ObjectType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ObjectTypes");
                });

            modelBuilder.Entity("DbPackage.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("CompletedAt")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("CreatedAt")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DepartureName")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeparturePoint")
                        .HasColumnType("TEXT");

                    b.Property<string>("DestinationName")
                        .HasColumnType("TEXT");

                    b.Property<string>("DestinationPoint")
                        .HasColumnType("TEXT");

                    b.Property<long?>("EndTime")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Mark")
                        .HasColumnType("INTEGER");

                    b.Property<float?>("Price")
                        .HasColumnType("REAL");

                    b.Property<long?>("StartTime")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TarifPlanId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DbPackage.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float?>("Balance")
                        .HasColumnType("REAL");

                    b.Property<float?>("Experience")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("DbPackage.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float?>("Amount")
                        .HasColumnType("REAL");

                    b.Property<long?>("CreatedAt")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("DbPackage.Models.TransactionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TransactionTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
