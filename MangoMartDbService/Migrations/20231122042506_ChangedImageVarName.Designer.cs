﻿// <auto-generated />
using System;
using MangoMartDbService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MangoMartDbService.Migrations
{
    [DbContext(typeof(LocalDbContext))]
    [Migration("20231122042506_ChangedImageVarName")]
    partial class ChangedImageVarName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("MangoMartDb.Models.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("InStock")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PageNumber")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Sku")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
