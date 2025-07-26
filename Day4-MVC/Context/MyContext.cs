using Microsoft.EntityFrameworkCore;
using MVC_DAY2.Models;

namespace Day4_MVC.Context
{
    public class MyContext : DbContext
    {
    
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=./;Database=MVC_D03;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var departments = new List<Department>()
            {
                new Department {  DeptId = 1 , DeptName = "SD" },
                new Department {  DeptId = 2 , DeptName = "UI" },
                new Department {  DeptId = 3 , DeptName = "Mob" },
                new Department {  DeptId = 4 , DeptName = "Network" },
            };

            var students = new List<Student>()
            {
    new Student { Id = 1, Name = "Ahmed", Age = 26 , Address = "cairo", DeptId = 1 },
    new Student { Id = 2, Name = "Mohamed", Age = 36 , Address = "Alex", DeptId = 2 },
    new Student { Id = 3, Name = "Sara", Age = 46 , Address = "Aswan", DeptId = 3 },
    new Student { Id = 4, Name = "Omar", Age = 25 , Address = "sqeda", DeptId = 4 },
    new Student { Id = 5, Name = "Ali", Age = 23 , Address = "magreat", DeptId = 1 },
    new Student { Id = 6, Name = "Mai", Age = 36 , Address = "NewYourk", DeptId = 2 },
    new Student { Id = 7, Name = "Ramy", Age = 49 , Address = "japan", DeptId = 3 },
    new Student { Id = 8, Name = "Hamada", Age = 18 , Address = "chena", DeptId = 4 },
    new Student { Id = 9, Name = "Hatem", Age = 26 , Address = "sadek", DeptId = 1 },
    new Student { Id = 10, Name = "Osama", Age = 25 , Address = "newsaty", DeptId = 2 },
            };

            modelBuilder
                .Entity<Department>()
                .HasData(departments);

            modelBuilder
                .Entity<Student>()
                .HasData(students);


            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
    }
}
