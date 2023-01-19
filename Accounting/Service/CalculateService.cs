using Accounting.Interfaces;
using Accounting.Models.Model;

namespace Accounting.Service
{
    public class CalculateService : ICalculateService
    {
        public ResCalculateModel CheckCalculateDebitAndCredit(List<ReqAccountRecordModel> cal)
        {
            int curCredit = 0;
            int curDebit = 0;
            int compareCreditDebit = 0;
            foreach (var record in cal)
            {
                record.credit += curCredit;
                record.debit += curDebit;
            }
            compareCreditDebit = curCredit - curDebit;
            ResCalculateModel resCalculate = new ResCalculateModel()
            {
                TotalCredit = curCredit,
                TotalDebit = curDebit,
                Balance = compareCreditDebit
            };
            return resCalculate;
        }
    }
}
