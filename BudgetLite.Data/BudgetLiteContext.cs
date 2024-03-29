﻿using BudgetLite.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BudgetLite.Data
{
    public class BudgetLiteContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        /// <summary>
        /// Name of DB
        /// </summary>
        public static readonly string BudgetLiteContextDb = nameof(BudgetLiteContext).ToLower();

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<BudgetPeriod> BudgetPeriods { get; set; }
        public DbSet<Budget> Budgets { get; set; }

        /// <summary>
        /// Creates a new <see cref="BudgetLiteContext"/>
        /// </summary>
        /// <param name="options">The DbContext options <see cref="DbContextOptions"/></param>
        public BudgetLiteContext(DbContextOptions<BudgetLiteContext> options) : base(options) { }

        /// <summary>
        /// Define the models.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/>.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasOne(x => x.BudgetPeriod).WithMany(x => x.Transactions);
            modelBuilder.Entity<BudgetPeriod>().HasOne(x => x.Budget).WithMany(x => x.BudgetPeriods);
            modelBuilder.Entity<Budget>().HasOne(x => x.User);

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Dispose pattern.
        /// </summary>
        public override void Dispose()
        {
            Debug.WriteLine($"{ContextId} context disposed.");
            base.Dispose();
        }

        /// <summary>
        /// Dispose pattern.
        /// </summary>
        /// <returns>A <see cref="ValueTask"/></returns>
        public override ValueTask DisposeAsync()
        {
            Debug.WriteLine($"{ContextId} context disposed async.");
            return base.DisposeAsync();
        }
    }
}

