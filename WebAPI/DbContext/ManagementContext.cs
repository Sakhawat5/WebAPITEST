using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI
{
    public class ManagementContext : DbContext
    {
        public ManagementContext(DbContextOptions<ManagementContext> options) 
            : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Designation> Designation { get; set; }
        public DbSet<Salary> Salary { get; set; }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>(entity =>
            //{
            //    entity.HasKey(e => e.DepartmentId);

            //    entity.ToTable("Employee");

            //    entity.Property(e => e.).IsRequired();

            //    entity.Property(e => e.Name).IsRequired();
            //});

            //modelBuilder.Entity<TblProduct>(entity =>
            //{
            //    entity.HasKey(e => e.ProductId);

            //    entity.ToTable("tbl_product");

            //    entity.Property(e => e.ProductId).HasColumnName("ProductID");

            //    entity.Property(e => e.Color).IsRequired();

            //    entity.Property(e => e.Name).IsRequired();

            //    entity.Property(e => e.Price).HasColumnType("money");

            //    entity.Property(e => e.ProductNumber).IsRequired();
            //});

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpCode);

                entity.ToTable("Employee");

                entity.Property(e => e.EmpName).IsRequired();
            });

            // [Asma Khalid]: Regster store procedure custom object.  
           // modelBuilder.Query<EmployeeDetails>();
            modelBuilder.Entity<EmployeeDetails>().Property(p => p.EmpName);
        }

    }
}
