using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Practice_01.Models
{
    public enum Department { Admin=1, Marketing, Software, Staff}
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime JoinDate { get; set; }
        public Department Department { get; set; }
        public decimal Salary { get; set; }
        public bool IsContinue { get; set; }
    }
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
        {
            Database.SetInitializer(new DbInitializer());
        }
        public DbSet<Employee> Employees { get; set; }
    }
    public class DbInitializer : DropCreateDatabaseIfModelChanges<EmployeeDbContext>
    {
        protected override void Seed(EmployeeDbContext db)
        {
            if (!db.Employees.Any())
            {
                db.Employees.Add(new Employee { EmployeeName = "MM", JoinDate = new DateTime(2022, 09, 01), Department = Department.Admin, Salary = 50000.00M, IsContinue = true });
                db.Employees.Add(new Employee { EmployeeName = "NN", JoinDate = new DateTime(2021, 10, 01), Department = Department.Marketing, Salary = 40000.00M, IsContinue = false });
                db.SaveChanges();
            }
        }
    }
}