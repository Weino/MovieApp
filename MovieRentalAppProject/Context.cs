using Microsoft.EntityFrameworkCore;
using System;
using static MovieRentalAppProject.Customer;

namespace MovieRentalAppProject
{
    public class Context : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rental> Sales { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(
                @"server=.\SQLEXPRESS;" +
                @"database=MySaleDatabase;" +
                @"trusted_connection=true;" +
                @"MultipleActiveResultSets=True"
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 1,
                FirstName = "William",
                LastName = "Weinö",
                Gender = Gender.Male
            });    
                
                
                

        }
    }
}
