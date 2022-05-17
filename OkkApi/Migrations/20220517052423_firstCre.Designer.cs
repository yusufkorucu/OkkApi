﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OkkApi.Models;

namespace OkkApi.Migrations
{
    [DbContext(typeof(OKKTechDbContext))]
    [Migration("20220517052423_firstCre")]
    partial class firstCre
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OkkApi.Models.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DataPulse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DurationTime")
                        .HasColumnType("int");

                    b.Property<int>("HStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("LoginLogoutDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("OkkApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Plate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Property")
                        .HasColumnType("int");

                    b.Property<string>("SpecialCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecialStatus")
                        .HasColumnType("int");

                    b.Property<long>("TCKNO")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OkkApi.Models.Record", b =>
                {
                    b.HasOne("OkkApi.Models.User", "Users")
                        .WithMany("Record")
                        .HasForeignKey("UsersId");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("OkkApi.Models.User", b =>
                {
                    b.Navigation("Record");
                });
#pragma warning restore 612, 618
        }
    }
}
