﻿// <auto-generated />
using Internship.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Internship.Models.Migrations
{
    [DbContext(typeof(InternshipContext))]
    [Migration("20171008204459_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Internship.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("State");

                    b.Property<int>("Zip");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Internship.Models.CptApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationStep");

                    b.Property<DateTime>("DateSignedByAcademicAdvisor");

                    b.Property<DateTime>("DateSignedByDean");

                    b.Property<DateTime>("DateSignedByDepartment");

                    b.Property<DateTime>("DateSignedByInstructor");

                    b.Property<DateTime>("DateSignedByStudent");

                    b.Property<DateTime>("DateSignedBySupervisorUponCompletion");

                    b.Property<int>("InternshipSemester");

                    b.Property<bool>("IsPartTime");

                    b.Property<string>("ReasonsForNoneApproval");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("CptApplications");
                });

            modelBuilder.Entity("Internship.Models.Employer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CptApplicationId");

                    b.Property<int>("EmployersAddressId");

                    b.Property<string>("EmployersName");

                    b.Property<string>("SupervisorEmail");

                    b.Property<string>("SupervisorName");

                    b.Property<int>("SupervisorPhone");

                    b.Property<string>("SupervisorTitle");

                    b.HasKey("Id");

                    b.HasIndex("CptApplicationId")
                        .IsUnique();

                    b.HasIndex("EmployersAddressId");

                    b.ToTable("Employers");
                });

            modelBuilder.Entity("Internship.Models.EmploymentAgreement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CptApplicationId");

                    b.Property<string>("DescriptionOfEmployment");

                    b.Property<DateTime>("EmploymentBeginDate");

                    b.Property<DateTime>("EmploymentEndDate");

                    b.Property<double>("HoursPerWeek");

                    b.Property<string>("JobResponsibilities");

                    b.Property<string>("JobTitle");

                    b.Property<double>("Salary");

                    b.Property<int>("SalaryType");

                    b.HasKey("Id");

                    b.HasIndex("CptApplicationId")
                        .IsUnique();

                    b.ToTable("EmployementAgreements");
                });

            modelBuilder.Entity("Internship.Models.LearningObjective", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CptApplicationId");

                    b.Property<string>("MeasureableLearningObjective");

                    b.Property<double>("SupervisorRating");

                    b.HasKey("Id");

                    b.HasIndex("CptApplicationId");

                    b.ToTable("LearningObjectives");
                });

            modelBuilder.Entity("Internship.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreditHoursRegisteredInSemester");

                    b.Property<int>("CurrentAddressId");

                    b.Property<string>("Degree");

                    b.Property<string>("Email");

                    b.Property<DateTime>("ExpectededGraduationDate");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsInternational");

                    b.Property<string>("LastName");

                    b.Property<string>("Major");

                    b.Property<double>("MajorGPA");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Password");

                    b.Property<int>("PermanentAddressId");

                    b.Property<string>("Phone");

                    b.Property<string>("Token");

                    b.Property<int>("UserType");

                    b.Property<int>("WNumber");

                    b.HasKey("Id");

                    b.HasIndex("CurrentAddressId");

                    b.HasIndex("PermanentAddressId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Internship.Models.CptApplication", b =>
                {
                    b.HasOne("Internship.Models.User", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Internship.Models.Employer", b =>
                {
                    b.HasOne("Internship.Models.CptApplication", "CptApplication")
                        .WithOne("Employer")
                        .HasForeignKey("Internship.Models.Employer", "CptApplicationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Internship.Models.Address", "EmployersAddress")
                        .WithMany()
                        .HasForeignKey("EmployersAddressId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Internship.Models.EmploymentAgreement", b =>
                {
                    b.HasOne("Internship.Models.CptApplication", "CptApplication")
                        .WithOne("EmploymentAgreement")
                        .HasForeignKey("Internship.Models.EmploymentAgreement", "CptApplicationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Internship.Models.LearningObjective", b =>
                {
                    b.HasOne("Internship.Models.CptApplication", "CptApplication")
                        .WithMany("LearningObjectives")
                        .HasForeignKey("CptApplicationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Internship.Models.User", b =>
                {
                    b.HasOne("Internship.Models.Address", "CurrentAddress")
                        .WithMany()
                        .HasForeignKey("CurrentAddressId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Internship.Models.Address", "PermanentAddress")
                        .WithMany()
                        .HasForeignKey("PermanentAddressId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
