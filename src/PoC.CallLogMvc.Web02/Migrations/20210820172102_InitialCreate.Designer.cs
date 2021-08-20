﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PoC.CallLogMvc.Web02.Data;

namespace PoC.CallLogMvc.Web02.Migrations
{
    [DbContext(typeof(HelpDeskDbContext))]
    [Migration("20210820172102_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PoC.CallLogMvc.Web02.Data.Models.CallLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CallStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Caller")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Problem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Solution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("WhenCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CallStatusId");

                    b.ToTable("CallLogs");
                });

            modelBuilder.Entity("PoC.CallLogMvc.Web02.Data.Models.CallStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CallStatus");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Name = "New"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Working"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Closed"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rejected"
                        });
                });

            modelBuilder.Entity("PoC.CallLogMvc.Web02.Data.Models.CallLog", b =>
                {
                    b.HasOne("PoC.CallLogMvc.Web02.Data.Models.CallStatus", "CallStatus")
                        .WithMany("CallLogs")
                        .HasForeignKey("CallStatusId");

                    b.Navigation("CallStatus");
                });

            modelBuilder.Entity("PoC.CallLogMvc.Web02.Data.Models.CallStatus", b =>
                {
                    b.Navigation("CallLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
