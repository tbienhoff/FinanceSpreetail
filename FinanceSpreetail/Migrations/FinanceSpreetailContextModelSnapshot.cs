﻿// <auto-generated />
using System;
using FinanceSpreetail.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinanceSpreetail.Migrations
{
    [DbContext(typeof(FinanceSpreetailContext))]
    partial class FinanceSpreetailContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinanceSpreetail.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("amount");

                    b.Property<string>("name");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("FinanceSpreetail.Models.Transaction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("amount");

                    b.Property<int>("categoryID");

                    b.Property<DateTime>("date");

                    b.Property<string>("name");

                    b.HasKey("ID");

                    b.HasIndex("categoryID");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("FinanceSpreetail.Models.Transaction", b =>
                {
                    b.HasOne("FinanceSpreetail.Models.Category", "category")
                        .WithMany("transactions")
                        .HasForeignKey("categoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}