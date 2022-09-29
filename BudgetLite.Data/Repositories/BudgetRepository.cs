using BudgetLite.Data.Models;

namespace BudgetLite.Data.Repositories
{
    public class BudgetRepository : IRepository<Budget>
    {
        private readonly BudgetLiteContext context;

        public BudgetRepository(BudgetLiteContext context)
        {
            this.context = context;
        }

        public async Task<bool> Delete(int id)
        {
            Budget? budget = await this.context.Budgets.FindAsync(id);

            if (budget == null)
            {
                throw new ArgumentException($"Budget with ID:{id} could not be found");
            }

            this.context.Budgets.Remove(budget);
            int result = await this.context.SaveChangesAsync();

            if (result == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<Budget> Get(int id)
        {
            Budget? budget = await this.context.Budgets.FindAsync(id);

            if (budget == null)
            {
                throw new ArgumentException($"Budget with ID:{id} could not be found");
            }

            return budget;
        }

        public IEnumerable<Budget> GetAll()
        {
            return this.context.Budgets.AsEnumerable();
        }

        public async Task<Budget> Insert(Budget entity)
        {
            await this.context.Budgets.AddAsync(entity);
            await this.context.SaveChangesAsync();

            return entity;
        }

        public async Task<Budget> Update(int id, Budget entity)
        {
            Budget? budget = await this.context.Budgets.FindAsync(id);

            if (budget == null)
            {
                throw new ArgumentException($"Budget with ID:{id} could not be found");
            }

            budget.Name = entity.Name;
            budget.Description = entity.Description;
            budget.Catagory = entity.Catagory;
            budget.Amount = entity.Amount;
            budget.ParentBudgetID = entity.ParentBudgetID;
            budget.DurationType = entity.DurationType;

            this.context.Budgets.Update(budget);
            var result = await this.context.SaveChangesAsync();

            if (result == 0)
            {
                throw new ApplicationException($"Was not able to update entity with ID:{id}");
            }

            return budget;
        }
    }
}
