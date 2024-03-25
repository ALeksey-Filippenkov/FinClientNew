﻿// <auto-generated />
using System;
using FinServer.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinServer.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240317105423_PersonHistoryTransferAdded")]
    partial class PersonHistoryTransferAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinServer.DbModels.DbHistoryTransfer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("MoneyTransfer")
                        .HasColumnType("float");

                    b.Property<int>("OperationType")
                        .HasColumnType("int");

                    b.Property<Guid?>("RecipientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("HistoryTransfers");
                });

            modelBuilder.Entity("FinServer.DbModels.DbPerson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Age")
                        .HasMaxLength(200)
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmailAdress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("FinServer.DbModels.DbPersonMoney", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Balance")
                        .HasColumnType("float");

                    b.Property<Guid?>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonMoneys");
                });

            modelBuilder.Entity("FinServer.DbModels.DbHistoryTransfer", b =>
                {
                    b.HasOne("FinServer.DbModels.DbPerson", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId");

                    b.HasOne("FinServer.DbModels.DbPerson", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("FinServer.DbModels.DbPersonMoney", b =>
                {
                    b.HasOne("FinServer.DbModels.DbPerson", "Person")
                        .WithMany("PersonMoneys")
                        .HasForeignKey("PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("FinServer.DbModels.DbPerson", b =>
                {
                    b.Navigation("PersonMoneys");
                });
#pragma warning restore 612, 618
        }
    }
}