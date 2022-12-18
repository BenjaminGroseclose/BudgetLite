using BudgetLite.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetLite.Data.Repositories
{
    public class BudgetPeriodRepository : IRepository<BudgetPeriod>
    {
        private readonly BudgetLiteContext context;

        public BudgetPeriodRepository(BudgetLiteContext context)
        {
            this.context = context;
        }

        public async Task<bool> Delete(int id)
        {
            BudgetPeriod? budgetPeriod = await this.context.BudgetPeriods.FindAsync(id);

            if (budgetPeriod == null)
            {
                throw new ArgumentException($"Budget Period with ID:{id} could not be found");
            }

            this.context.BudgetPeriods.Remove(budgetPeriod);
            int result = await this.context.SaveChangesAsync();

            if (result == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<BudgetPeriod> Get(int id)
        {
            BudgetPeriod? budgetPeriod = await this.context.BudgetPeriods.Include(x => x.Budget).Include(x => x.Transactions).FirstOrDefaultAsync(x => x.BudgetPeriodID == id);

            if (budgetPeriod == null)
            {
                throw new ArgumentException($"Budget with ID:{id} could not be found");
            }

            return budgetPeriod;
        }

        public IEnumerable<BudgetPeriod> GetAll()
        {
            return this.context.BudgetPeriods.Include(x => x.Budget).Include(x => x.Transactions).AsEnumerable();
        }

        public async Task<BudgetPeriod> Insert(BudgetPeriod entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.LastModifiedDate = DateTime.Now;

            await this.context.BudgetPeriods.AddAsync(entity);
            await this.context.SaveChangesAsync();

            return entity;
        }

        public async Task<BudgetPeriod> Update(int id, BudgetPeriod entity)
        {
            BudgetPeriod? budgetPeriod = await this.context.BudgetPeriods.FindAsync(id);

            if (budgetPeriod == null)
            {
                throw new ArgumentException($"Transaction with ID:{id} could not be found");
            }

            budgetPeriod.StartDate = entity.StartDate;
            budgetPeriod.EndDate = entity.EndDate;
            budgetPeriod.DurationType = entity.DurationType;

            budgetPeriod.LastModifiedDate = DateTime.Now;

            this.context.BudgetPeriods.Update(budgetPeriod);
            var result = await this.context.SaveChangesAsync();

            if (result == 0)
            {
                throw new ApplicationException($"Was not able to update entity with ID:{id}");
            }

            return budgetPeriod;
        }
    }
}
