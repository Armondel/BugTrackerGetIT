﻿namespace BugTrackerGetIT.Persistence.DbConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using BugTrackerGetIT.Core.Bug;
    using BugTrackerGetIT.Core.User;
    using BugTrackerGetIT.Core.BugHistory;

    public class ApplicationDbContext : DbContext     
    {
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<BugHistory> BugHistory { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}