using AttendIO.Data.DbConfig;
using AttendIO.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationLog>    ApplicationLogs { get; set; }
        public DbSet<LogType>   LogTypes { get; set; }
        public DbSet<ModifiedLog> ModifiedLogs { get; set; }
        public DbSet<TimeLog> TimeLogs { get; set; }
        public DbSet<User> Users { get; set; }
        public object DbConfigurationManager { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DbConfigManager.Configure(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
