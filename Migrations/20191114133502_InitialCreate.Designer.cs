﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Orto;

namespace Orto.Migrations
{
    [DbContext(typeof(SlowaN))]
    [Migration("20191114133502_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("Orto.Przyklady", b =>
                {
                    b.Property<int>("przykladyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("przykladSample")
                        .HasColumnType("TEXT");

                    b.HasKey("przykladyId");

                    b.ToTable("BazaSlow");
                });
#pragma warning restore 612, 618
        }
    }
}
