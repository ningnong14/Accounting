using Accounting.Models;
using Ardalis.Specification;

namespace Accounting.Specifications
{
    public class ExampleSpecification : Specification<AccountRecord>, ISingleResultSpecification<AccountRecord>
    {
        public ExampleSpecification() 
        {
            Query.Where(log => log.Debit == "");
        }
    }
}
