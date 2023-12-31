﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PAMW5_MVC.DataAccess;

#nullable disable

namespace PAMW5_MVC.Migrations
{
    [DbContext(typeof(PostOfficeContext))]
    [Migration("20231120071237_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("PAMW5_MVC.Models.Parcel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Receiver")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Parcels");
                });
#pragma warning restore 612, 618
        }
    }
}
