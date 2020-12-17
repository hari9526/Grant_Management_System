﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using data.Data;

namespace data.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("models.DbModels.ApplicantDetail", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("Date");

                    b.Property<bool>("Disabled")
                        .HasColumnType("bit");

                    b.Property<int>("EducationalDetailId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("GrantId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("EducationalDetailId");

                    b.ToTable("ApplicantDetails");
                });

            modelBuilder.Entity("models.DbModels.EducationDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("InstitutionName")
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("YearOfCompletion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EducationDetails");
                });

            modelBuilder.Entity("models.DbModels.GrantProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProgramCode")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ProgramName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("GrantProgram");
                });

            modelBuilder.Entity("models.DbModels.UserGrantMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("GrantId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GrantId");

                    b.HasIndex("UserId");

                    b.ToTable("UserGrantMappings");
                });

            modelBuilder.Entity("models.DbModels.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UpdatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("models.DbModels.ApplicantDetail", b =>
                {
                    b.HasOne("models.DbModels.EducationDetail", null)
                        .WithMany("ApplicantDetails")
                        .HasForeignKey("EducationalDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("models.DbModels.UserInfo", null)
                        .WithMany("ApplicantDetails")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("models.DbModels.UserGrantMapping", b =>
                {
                    b.HasOne("models.DbModels.GrantProgram", null)
                        .WithMany("UserGrantMappings")
                        .HasForeignKey("GrantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("models.DbModels.UserInfo", null)
                        .WithMany("UserGrantMappings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("models.DbModels.EducationDetail", b =>
                {
                    b.Navigation("ApplicantDetails");
                });

            modelBuilder.Entity("models.DbModels.GrantProgram", b =>
                {
                    b.Navigation("UserGrantMappings");
                });

            modelBuilder.Entity("models.DbModels.UserInfo", b =>
                {
                    b.Navigation("ApplicantDetails");

                    b.Navigation("UserGrantMappings");
                });
#pragma warning restore 612, 618
        }
    }
}
