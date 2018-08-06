﻿// <auto-generated />
using System;
using ETLSuite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ETLSuite.Data.Migrations
{
    [DbContext(typeof(ETLDataContext))]
    [Migration("20180804042653_Added_Description_To_DbConnectionDefinition")]
    partial class Added_Description_To_DbConnectionDefinition
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ETLSuite.Data.Entities.DbConnectionDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConnectionString")
                        .IsRequired();

                    b.Property<DateTime?>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("ProjectId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("DbConnectionDefinitions");

                    b.HasData(
                        new { Id = 1, ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ETLSuite_UploadSource;Integrated Security=True", Created = new DateTime(2018, 8, 3, 21, 26, 52, 944, DateTimeKind.Local), CreatedBy = "test", Description = "Sql Server 1 description", Modified = new DateTime(2018, 8, 3, 21, 26, 52, 944, DateTimeKind.Local), ModifiedBy = "test", Name = "Sql Server 1", ProjectId = 1, Type = 0 }
                    );
                });

            modelBuilder.Entity("ETLSuite.Data.Entities.LogEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<int>("Level");

                    b.Property<string>("Message")
                        .IsRequired();

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.HasKey("Id");

                    b.ToTable("LogEntries");
                });

            modelBuilder.Entity("ETLSuite.Data.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new { Id = 1, Created = new DateTime(2018, 8, 3, 21, 26, 52, 939, DateTimeKind.Local), CreatedBy = "test", Description = "Project 1 Description", Modified = new DateTime(2018, 8, 3, 21, 26, 52, 941, DateTimeKind.Local), ModifiedBy = "test", Name = "Project 1", Status = 0 }
                    );
                });

            modelBuilder.Entity("ETLSuite.Data.Entities.DbConnectionDefinition", b =>
                {
                    b.HasOne("ETLSuite.Data.Entities.Project", "Project")
                        .WithMany("DbConnectionDefinitions")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}