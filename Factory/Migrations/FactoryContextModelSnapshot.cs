﻿// <auto-generated />
using System;
using Factory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Factory.Migrations
{
    [DbContext(typeof(FactoryContext))]
    partial class FactoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Factory.Models.Engineer", b =>
                {
                    b.Property<int>("EngineerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateHired")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("EngineerId");

                    b.ToTable("Engineers");
                });

            modelBuilder.Entity("Factory.Models.Machine", b =>
                {
                    b.Property<int>("MachineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("MachineId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("Factory.Models.MachineEngineer", b =>
                {
                    b.Property<int>("MachineEngineerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EngineerId")
                        .HasColumnType("int");

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.HasKey("MachineEngineerId");

                    b.HasIndex("MachineId");

                    b.HasIndex("EngineerId", "MachineId")
                        .IsUnique();

                    b.ToTable("MachineEngineers");
                });

            modelBuilder.Entity("Factory.Models.MachineEngineer", b =>
                {
                    b.HasOne("Factory.Models.Engineer", "Engineer")
                        .WithMany("MachineEngineers")
                        .HasForeignKey("EngineerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Factory.Models.Machine", "Machine")
                        .WithMany("MachineEngineers")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Engineer");

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("Factory.Models.Engineer", b =>
                {
                    b.Navigation("MachineEngineers");
                });

            modelBuilder.Entity("Factory.Models.Machine", b =>
                {
                    b.Navigation("MachineEngineers");
                });
#pragma warning restore 612, 618
        }
    }
}
