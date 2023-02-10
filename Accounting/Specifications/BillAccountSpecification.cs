
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
        public BillAccountSpecification(DateTime dateTimeTo, DateTime dateTimeFrom,string codeMainAccount)
        {
            Query.Where(a => a.DateTimeTo >= dateTimeTo && a.DateTimeTo <= dateTimeFrom && a.MainAccount.Equals(codeMainAccount));
        }
    }
}
