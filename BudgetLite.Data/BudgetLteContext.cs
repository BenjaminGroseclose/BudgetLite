using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BudgetLite.Data
{
    public class BudgetLteContext : DbContext
    {
        /// <summary>
        /// Name of DB
        /// </summary>
        public static readonly string BudgetLteContextDb = nameof(BudgetLteContext).ToLower();

        /// <summary>
        /// Creates a new <see cref="BudgetLteContext"/>
        /// </summary>
        /// <param name="options">The DbContext options <see cref="DbContextOptions"/></param>
        public BudgetLteContext(DbContextOptions<BudgetLteContext> options): base(options) { }

        /// <summary>
        /// Define the models.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/>.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

