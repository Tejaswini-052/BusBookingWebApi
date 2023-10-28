using BusBookingWebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace BusBookingWebApi.Data
{

   
    public class BookDbContext:IdentityDbContext<IdentityUser>
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }

        public DbSet<FeedBack> FeedBack { get; set; }

        public DbSet<RegisterUser> registerUser { get; set; }

        public DbSet<CardDetails> CardDetails { get; set; }
        public DbSet<BusRoute> routes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
        }

        protected static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                 new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
                );

        }



        // public DateOnly(int year, int month, int day);

    }
}
