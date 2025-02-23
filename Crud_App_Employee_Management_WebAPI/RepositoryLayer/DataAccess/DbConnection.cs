using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.DataAccess
{
    public class DbConnection :DbContext
    {
        public DbConnection(DbContextOptions<DbConnection> options):base(options) 
        {
        
        }
        public DbSet<EmployeeClass> EmployeeClass { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Grade> Grades { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .Property(u => u.roles)
                .HasConversion(
                    roles => string.Join(",", roles), // Convert List<Role> to string
                    roles => roles.Split(",", StringSplitOptions.RemoveEmptyEntries)
                                  .Select(role => Enum.Parse<Role>(role))
                                  .ToList() // Convert string to List<Role>
                );

            modelBuilder.Entity<EmployeeClass>()
                .HasOne(e => e.Grade)
                .WithMany(g => g.Employees)
                .HasForeignKey(e => e.EmployeeGrade);

        }
    }
}
