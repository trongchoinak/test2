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
        }
    }
}
