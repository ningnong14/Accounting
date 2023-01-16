using Accounting.Interfaces;
using Accounting.Models;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;

namespace Accounting.Service
{
    public class AccountingRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
    {
        public AccountingRepository(AccountingContext dbContext) : base(dbContext)
        {

        }
    }
}
