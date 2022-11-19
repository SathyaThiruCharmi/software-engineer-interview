﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zip.InstallmentService.Api.Data;

#nullable disable

namespace Zip.InstallmentService.Api.Migrations
{
    [DbContext(typeof(ZipInstallmentServiceApiContext))]
    partial class ZipInstallmentServiceApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Zip.InstallmentsService.Installment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("PaymentPlanId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PaymentPlanId");

                    b.ToTable("Installment");
                });

            modelBuilder.Entity("Zip.InstallmentsService.PaymentPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Frequeny")
                        .HasColumnType("int");

                    b.Property<int>("Installment")
                        .HasColumnType("int");

                    b.Property<decimal>("PurchaseAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("PaymentPlan");
                });

            modelBuilder.Entity("Zip.InstallmentsService.Installment", b =>
                {
                    b.HasOne("Zip.InstallmentsService.PaymentPlan", null)
                        .WithMany("Installments")
                        .HasForeignKey("PaymentPlanId");
                });

            modelBuilder.Entity("Zip.InstallmentsService.PaymentPlan", b =>
                {
                    b.Navigation("Installments");
                });
#pragma warning restore 612, 618
        }
    }
}
