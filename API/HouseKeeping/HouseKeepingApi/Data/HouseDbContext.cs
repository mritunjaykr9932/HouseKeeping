using HouseKeepingApi.Models; //*
using Microsoft.EntityFrameworkCore;

namespace HouseKeepingApi.Data
{
   
    
        public class HouseDbContext : DbContext
        {
            public HouseDbContext(DbContextOptions options) : base(options)
            {
            }

            //DbSet

            public DbSet<HouseKeeping> Housekeepings { get; set; }
        }
}
