using Microsoft.EntityFrameworkCore;
using FinancePreferenceSys.Models;
using System.Collections.Generic;

namespace FinancePreferenceSys.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet 對應資料表
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<LikeList> LikeLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LikeList>().ToTable("LikeList");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Product>().ToTable("Product");

            // 主鍵
            modelBuilder.Entity<User>().HasKey(u => u.UserID);
            modelBuilder.Entity<Product>().HasKey(p => p.No);
            modelBuilder.Entity<LikeList>().HasKey(l => l.SN);

        }
    }
}
