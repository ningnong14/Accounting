using Accounting.Models;
using Ardalis.Specification;

namespace Accounting.Specifications
{
    public class DebitCodeGetByCodeSpecification : Specification<CodeDebit>, ISingleResultSpecification<CodeDebit>
    {
        public DebitCodeGetByCodeSpecification(string code)
        {
            Query.Where(codeData => codeData.Code.Equals(code));
        }

    }
}
