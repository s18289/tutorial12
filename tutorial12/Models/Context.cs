using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial12.Configurations;

namespace tutorial12.Models
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {


        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Confectionery> Confectionery { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Confectionery_Order> Confectionery_Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new ConfectioneryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new Confectionery_OrderConfiguration());
        }
    }
}