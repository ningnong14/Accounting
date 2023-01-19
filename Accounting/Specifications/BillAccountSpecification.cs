
using Accounting.Models;
using Ardalis.Specification;

namespace Accounting.Specifications
{
    public class BillAccountSpecification : Specification<RecordAccounting> , ISingleResultSpecification<RecordAccounting>
    {
        public BillAccountSpecification(DateTime dateTimeTo,DateTime dateTimeFrom) 
        {
            Query.Where(a => a.DateTimeTo >= dateTimeTo && a.DateTimeTo <= dateTimeFrom);
        }
    }
}
