using Accounting.Models;
using Ardalis.Specification;
using System.Composition.Convention;

namespace Accounting.Specifications
{
    public class BillRecordSpecification : Specification<BillRecord> , ISingleResultSpecification<BillRecord>
    {
        public BillRecordSpecification(int billId) 
        {
            Query.Where(noBill => noBill.BillId == billId);
        }
        public BillRecordSpecification(DateTime dateTimeto,DateTime dateTimeFrom)
        {
            Query.Where(Bill => Bill.Date <= dateTimeFrom);
        }
    }
}
