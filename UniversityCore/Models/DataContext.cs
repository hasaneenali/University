using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityCore.Entities;

namespace UniversityCore.Models
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<College>(entity =>
            //{
            //    entity.HasKey(e => e.CollegeId)
            //        .HasName("PK_College");

            //    entity.Property(e => e.ImageUrl).HasMaxLength(1000);

            //    entity.Property(e => e.Name).HasMaxLength(1000);

            //    entity.HasOne(d => d.University)
            //        .WithMany(p => p.Colleges)
            //        .HasForeignKey(d => d.UniversityId)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_College_University");
            //});

            //modelBuilder.Entity<Department>(entity =>
            //{
            //    entity.HasKey(e => e.DepartmentId)
            //        .HasName("PK_Department");

            //    entity.Property(e => e.ImageUrl).HasMaxLength(1000);

            //    entity.Property(e => e.Name).HasMaxLength(1000);

            //    entity.HasOne(d => d.College)
            //        .WithMany(p => p.Departments)
            //        .HasForeignKey(d => d.CollegeId)
            //        .HasConstraintName("FK_Department_College");

            //    entity.HasOne(d => d.University)
            //        .WithMany(p => p.Departments)
            //        .HasForeignKey(d => d.UniversityId)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_Department_University");
            //});

            //modelBuilder.Entity<Entities.University>(entity =>
            //{
            //    entity.HasKey(e => e.UniversityId)
            //        .HasName("PK_University");

            //    entity.Property(e => e.ImageUrl).HasMaxLength(1000);

            //    entity.Property(e => e.Name).HasMaxLength(1000);
            //});

        }


        public DbSet<Entities.University> Universities { get; set; }
        public DbSet<College> Colleges { get; set; }

        public DbSet<Department> Departments { get; set; }


        public DbSet<Student> Students { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Image> Images { get; set; }


    }
}
