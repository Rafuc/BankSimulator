﻿// <auto-generated />
using System;
using BankSimulator.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankSimulator.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20190212195318_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BankSimulator.Model.Account", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDayDate");

                    b.Property<decimal>("Cash");

                    b.Property<string>("FirstName");

                    b.Property<string>("LiveAddres");

                    b.Property<string>("Password");

                    b.Property<int>("PhoneNumber");

                    b.Property<string>("SecondName");

                    b.HasKey("IdUser");

                    b.ToTable("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
