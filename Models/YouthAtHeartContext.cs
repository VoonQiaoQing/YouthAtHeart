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
        public DbSet<Test> Test { get; set; }
        public DbSet<HomeInfo> HomeInfo { get; set; }
        public DbSet<WorkshopInfo> WorkshopInfo { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
    }
}
