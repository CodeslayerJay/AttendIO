using AttendIO.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Data.DbConfig
{
    public static class DbConfigManager
    {
        public static void Configure(ModelBuilder builder)
        {
            ConfiguretUser(builder);
            ConfigureTimeLog(builder);
            ConfigureLogType(builder);
            ConfigureModifiedLog(builder);
        }

        private static void ConfigureModifiedLog(ModelBuilder builder)
        {
            var e = builder.Entity<ModifiedLog>();
            e.Property(x => x.ChangedValue).IsRequired(false);
            e.Property(x => x.OriginalValue).IsRequired(false);
            e.Property(x => x.PropertyChanged).IsRequired(true);
            e.HasOne(x => x.ModifiedByUser).WithMany(x => x.ModifiedLogs).HasForeignKey(x => x.ModifiedById).OnDelete(DeleteBehavior.NoAction);
            e.HasOne(x => x.TimeLog).WithMany(x => x.ModifiedLogs).HasForeignKey(x => x.TimeLogId).OnDelete(DeleteBehavior.NoAction);

        }

        private static void ConfigureLogType(ModelBuilder builder)
        {
            
            var e = builder.Entity<LogType>();
            e.Property(x => x.Code).IsRequired(false).HasMaxLength(10);
            e.Property(x => x.Name).IsRequired(true).HasMaxLength(20);
            e.HasMany(x => x.TimeLogs).WithOne(x => x.LogType).HasForeignKey(x => x.LogTypeId).OnDelete(DeleteBehavior.NoAction);
        }

        private static void ConfigureTimeLog(ModelBuilder builder)
        {
            var e = builder.Entity<TimeLog>();
            e.HasOne(x => x.User).WithMany(x => x.TimeLogs).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            e.HasOne(x => x.LogType).WithMany(x => x.TimeLogs).HasForeignKey(x => x.LogTypeId).OnDelete(DeleteBehavior.NoAction);
            e.HasMany(x => x.ModifiedLogs).WithOne(x => x.TimeLog).HasForeignKey(x => x.TimeLogId).OnDelete(DeleteBehavior.NoAction);
            
        }

        private static void ConfiguretUser(ModelBuilder builder)
        {
            var e = builder.Entity<User>();
            e.Property(x => x.Username).IsRequired(true).HasMaxLength(50);
            e.Property(x => x.FirstName).IsRequired(true).HasMaxLength(30);
            e.Property(x => x.LastName).IsRequired(true).HasMaxLength(30);
            e.Property(x => x.Password).IsRequired(true).HasMaxLength(50);
            e.Property(x => x.EmailAddress).IsRequired(true).HasMaxLength(50);
            e.HasMany(x => x.TimeLogs).WithOne(x => x.User).OnDelete(DeleteBehavior.NoAction);
            e.HasMany(x => x.ModifiedLogs).WithOne(x => x.ModifiedByUser).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
