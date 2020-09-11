﻿using CustomerTrackingAppReact.Entities;
using CustomerTrackingAppReact.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTrackingAppReact.Persistence.EF
{
    public class SQLiteDBContext : DbContext
    {
        public DbSet<Activity> Activity { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Log> Log { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=C:\\Workspace\\github\\CustomerTrackingApp\\CustomerTrackingApp.sqlite");

    }
}
