using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


namespace YouthAtHeart.Models
{
    public class YouthAtHeartContext: DbContext
    {
        private readonly IConfiguration _config;
        public YouthAtHeartContext(IConfiguration configuration)
        {
            _config = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _config.GetConnectionString("MyConn");
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.userId);
                entity.Property(x => x.userId).ValueGeneratedOnAdd();
            });
        }
        public DbSet<Test> Test { get; set; }
        public DbSet<HomeInfo> HomeInfo { get; set; }
        public DbSet<WorkshopInfo> WorkshopInfo { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<FAQ> FAQ { get; set; }
    }
}
