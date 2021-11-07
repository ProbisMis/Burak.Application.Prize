using Burak.Application.Prize.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            //modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Player> player { get; set; }
        public virtual DbSet<Wallet> wallet { get; set; }
        public virtual DbSet<Rewards> rewards { get; set; }
        public virtual DbSet<LevelCompletionReward> levelcompletionreward { get; set; }
    }
}
