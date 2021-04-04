﻿using Microsoft.EntityFrameworkCore;
using ModulosUsuario.Models;

namespace ModulosUsuario.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
             .HasMany(a => a.Addresses)
             .WithOne(u => u.User)
             .IsRequired();
            modelBuilder.Entity<AddressUser>()
             .HasOne(a => a.User)
             .WithMany(u => u.Addresses)
             .HasForeignKey(u => u.UserId)
             .IsRequired();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AddressUser> AddressUser { get; set; }
    }
}



