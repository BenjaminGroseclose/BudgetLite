using BudgetLite.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetLite.Data.Repositories
{
    public class TransactionRepository : IRepository<Transaction>
    {
        private readonly BudgetLiteContext context;

        public TransactionRepository(BudgetLiteContext context)
        {
            this.context = context;
        }

        public async Task<bool> Delete(int id)
        {
            Transaction transaction = await this.context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                throw new ArgumentException($"Transaction with ID:{id} could not be found");
            }

            this.context.Transactions.Remove(transaction);
            int result = await this.context.SaveChangesAsync();

            if (result == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<Transaction> Get(int id)
        {
            Transaction transaction = await this.context.Transactions.FindAsync(id);

            if (transaction == null )
            {
                throw new ArgumentException($"Transaction with ID:{id} could not be found");
            }

            return transaction;
        }

        public IEnumerable<Transaction> GetAll()
        {
            return this.context.Transactions.Include(x => x.BudgetPeriod).ThenInclude(x => x.Budget).AsEnumerable();
        }

        public async Task<Transaction> Insert(Transaction entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.LastModifiedDate= DateTime.Now;

            await this.context.Transactions.AddAsync(entity);
            await this.context.SaveChangesAsync();

            return entity;
        }

        public async Task<Transaction> Update(int id, Transaction entity)
        {
            Transaction transaction = await this.context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                throw new ArgumentException($"Transaction with ID:{id} could not be found");
            }

            transaction.Amount = entity.Amount;
            transaction.Date = entity.Date;
            transaction.BudgetPeriodID = entity.BudgetPeriodID;

            transaction.LastModifiedDate = DateTime.Now;

            this.context.Transactions.Update(transaction);
            var result = await this.context.SaveChangesAsync();

            if (result == 0)
            {
                throw new ApplicationException($"Was not able to update entity with ID:{id}");
            }

            return transaction;
        }
    }
}
