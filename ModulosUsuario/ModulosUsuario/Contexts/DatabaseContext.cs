using Microsoft.EntityFrameworkCore;
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

            modelBuilder.Entity<UsersPermissions>()
                .HasKey(sc => new { sc.UserId, sc.PermissionId });

            modelBuilder.Entity<Product>()
                .HasMany(pt => pt.ProductTransactions)
                .WithOne(p => p.Product)
                .IsRequired();

            modelBuilder.Entity<Material>()
                .HasMany(mt => mt.MaterialTransactions)
                .WithOne(m => m.Material)
                .IsRequired();

            modelBuilder.Entity<Tools>()
                .HasMany(tt => tt.ToolsTransactions)
                .WithOne(t => t.Tool)
                .IsRequired();

            modelBuilder.Entity<Branch>()
                .HasOne(s => s.Stock)
                .WithOne(b => b.Branch)
                .IsRequired();

            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Branch)
                .WithOne(b => b.Stock)
                .IsRequired();

            modelBuilder.Entity<ToolsLog>()
                .HasOne(t => t.Tool)
                .WithMany(tl => tl.ToolsLogs)
                .HasForeignKey(tl => tl.ToolsId)
                .IsRequired();

            modelBuilder.Entity<ProductTransaction>()
                .HasOne(p => p.Product)
                .WithMany(pt => pt.ProductTransactions)
                .HasForeignKey(pt => pt.ProductId)
                .IsRequired();

            modelBuilder.Entity<MaterialTransaction>()
                .HasOne(m => m.Material)
                .WithMany(mt => mt.MaterialTransactions)
                .HasForeignKey(mt => mt.MaterialId)
                .IsRequired();

            modelBuilder.Entity<ToolsTransaction>()
                .HasOne(t => t.Tool)
                .WithMany(tt => tt.ToolsTransactions)
                .HasForeignKey(tt => tt.ToolId)
                .IsRequired();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AddressUser> AddressUser { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<UsersPermissions> UsersPermissions { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<UnityType> UnityType { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Tools> Tools { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<ProductTransaction> ProductTransaction { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<ToolsLog> ToolsLog { get; set; }
        public DbSet<ToolsTransaction> ToolsTransaction { get; set; }
        public DbSet<MaterialTransaction> MaterialTransaction { get; set; }
        public DbSet<TransactionType> TransactionType { get; set; }
    }
}


