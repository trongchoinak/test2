using Microsoft.EntityFrameworkCore;
using test2.Models;

namespace test2.Data
{
    public class test2Dbcontext : DbContext
    {
        public test2Dbcontext(DbContextOptions<test2Dbcontext> options) : base(options)
        {
        }
        public DbSet<student> students { get; set; }
        public DbSet<studentcourseid> studentcourseids { get; set; }
        public DbSet<courses> courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<courses>().HasKey(c => c.courseid);


            // Định nghĩa các quan hệ giữa các bảng ở đây
            modelBuilder.Entity<studentcourseid>()
                .HasOne(b => b.student)
                .WithMany(a => a.studentcourseids)
                .HasForeignKey(b => b.id);
            modelBuilder.Entity<studentcourseid>()
           .HasOne(c => c.courses)
           .WithMany(s => s.studentcourseids)
           .HasForeignKey(e => e.courseid);

            new DbInitializer(modelBuilder).Seed();
        }

        public class DbInitializer
        {
            private readonly ModelBuilder _builder;
            public DbInitializer(ModelBuilder builder)
            {
                this._builder = builder;
            }

            public void Seed()
            {
                _builder.Entity<student>(s =>
                {
                    s.HasData(new student
                    {
                        id ="mot",
                        name = "Trọng ynn "
                    });
                    s.HasData(new student
                    {
                        id ="hai",
                        name = "Nguyễn Phạm Phương Linh"
                    });
                });
                _builder.Entity<courses>(c =>
                {
                    c.HasData(new courses
                    {
                        courseid = "ba",
                        coursename = "Toán",
                        description = "Môn học dễ vl "
                    });
                    c.HasData(new courses
                    {
                        courseid ="bốn",
                        coursename = "Tiếng anh ",
                        description = "Tha",
                    });
                });
                _builder.Entity<Models.studentcourseid>(sc =>
                {
                    sc.HasData(new Models.studentcourseid
                    {
                        id = "một",
                        courseid ="ba"
                    });
                    sc.HasData(new Models.studentcourseid
                    {
                        id = "hai ",
                        courseid = "bốn"
                    }); ;
                });
            }
        }
    }
}
