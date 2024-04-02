﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test2.Data;

#nullable disable

namespace test2.Migrations
{
    [DbContext(typeof(test2Dbcontext))]
    partial class test2DbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("test2.Models.courses", b =>
                {
                    b.Property<string>("courseid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("coursename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("courseid");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("test2.Models.student", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("students");
                });

            modelBuilder.Entity("test2.Models.studentcourseid", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("courseid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("courseid");

                    b.ToTable("studentcourseids");
                });

            modelBuilder.Entity("test2.Models.studentcourseid", b =>
                {
                    b.HasOne("test2.Models.courses", "courses")
                        .WithMany("studentcourseids")
                        .HasForeignKey("courseid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("test2.Models.student", "student")
                        .WithMany("studentcourseids")
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("courses");

                    b.Navigation("student");
                });

            modelBuilder.Entity("test2.Models.courses", b =>
                {
                    b.Navigation("studentcourseids");
                });

            modelBuilder.Entity("test2.Models.student", b =>
                {
                    b.Navigation("studentcourseids");
                });
#pragma warning restore 612, 618
        }
    }
}
