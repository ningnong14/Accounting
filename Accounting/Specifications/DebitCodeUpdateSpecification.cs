using Accounting.Models;
using Ardalis.Specification;

namespace Accounting.Specifications
{
    public class DebitCodeUpdateSpecification : Specification<CodeDebit> , ISingleResultSpecification<CodeDebit>
    {
        public DebitCodeUpdateSpecification(int id) 
        {
            Query.
                Where(code => code.Id.Equals(id));
        }
    }
}
